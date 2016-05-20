using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ZedGraph;

namespace Digital_Pulse_Generator.WaveCalculator
{
    class GaussianCurve : Wave
    {
        private double area;
        private PointPair t50Raise;
        private PointPair t50Fall;
        private double timeOfFlight;

        public double Area
        {
            get { return area; }
        }
        
        public PointPair m_T50Raise
        {
            get { return t50Raise; }
        }

        public PointPair m_T50Fall
        {
            get { return t50Fall; }
        }

        public double TOF
        {
            get { return timeOfFlight; }
        }

        public GaussianCurve()
        {
        }

        public GaussianCurve(double a, double b, double c, double xLimit, double xInterval)
        {
            Create(a, b, c, xLimit, xInterval);
            CalculateParameters();
        }

        public void Add(double x, double y)
        {
            m_PointsList.Add(x, y);
        }

        public void Create(double a, double b, double c, double xLimit, double xInterval)
        {
            m_PointsList = new PointPairList();

            double x = 0, y = 0;
            for (double i = 0; i < xLimit; i += xInterval)
            {
                x = (double)i;
                double newC = (2 * Math.Pow(c, 2));
                y = a * Math.Pow(Math.E, -1 * ((Math.Pow(x - b, 2)) / newC));
                m_PointsList.Add(x, y);

                if ((m_Peak == null) || (m_Peak.Y < y))
                {
                    m_Peak = m_PointsList[m_PointsList.Count - 1];
                }                
            }

            CalculateParameters();
        }

        public void CalculateParameters()
        {
            if (m_PointsList != null && m_PointsList.Count != 0)
            {
                CalculateArea();
                CalculateT50Raise();
                CalculateT50Fall();
                CalculateTOF();
            }
        }

        private void CalculateArea()
        {
            area = 0;
            for (int i = 0; i < m_PointsList.Count; i++)
            {
                area += m_PointsList[i].Y;
            }
        }

        public int CalculateT50Raise()
        {
            t50Raise = findClosestPointsToYValue(0, m_Peak.Y/2);
            return m_PointsList.IndexOf(t50Raise);
        }

        public int CalculateT50Fall()
        {
            t50Fall = findClosestPointsToYValue(m_PointsList.IndexOf(m_Peak), m_Peak.Y/2);
            return m_PointsList.IndexOf(m_T50Fall);
        }

        private void CalculateTOF()
        {
            timeOfFlight = m_T50Fall.X - t50Raise.X;
        }

        private PointPair findClosestPointsToYValue(int startingIndex, double yValue)
        {
            PointPair beforeY = new PointPair(0, 0);
            PointPair afterY = new PointPair(0, 0);

            // Check wether or not the y value at the starting index is less than the target y value.
            bool startingPointLessThanYValue = m_PointsList[startingIndex].Y - yValue < 0;

            for (int i = startingIndex; i < m_PointsList.Count; i++)
            {
                beforeY = afterY;
                afterY = m_PointsList[i];
                if ((startingPointLessThanYValue && afterY.Y > yValue) || (!startingPointLessThanYValue && afterY.Y < yValue))
                    break;
            }
            return getClosestPointUsingYCoordinate(beforeY, afterY, yValue);
        }

        private PointPair getClosestPointUsingYCoordinate(PointPair a, PointPair b, double ref_value)
        {
            // If a and b are equal, it will bias towards a. 
            double ref_a = Math.Abs(a.Y - ref_value);
            double ref_b = Math.Abs(b.Y - ref_value);
            if (ref_a <= ref_b)
                return a;
            return b;
        }

        #region Stats

        public override string GetAnalogStats()
        {
            StringBuilder gaussianString = new StringBuilder();

            gaussianString.AppendFormat("{0}:\t\t{1:0.00} V @ {2:0.00} ns\n", 
                                        "Peak", m_Peak.Y, m_Peak.X);
            gaussianString.AppendFormat("{0}:\t{1:0.00} V @ {2:0.00} ns\n", 
                                        "T50 Raise", m_T50Raise.Y, m_T50Raise.X);
            gaussianString.AppendFormat("{0}:\t\t{1:0.00} V @ {2:0.00} ns\n", 
                                        "T50 Fall", m_T50Fall.Y, m_T50Fall.X);

            gaussianString.Append(GetTOFAndAreaStats());

            return gaussianString.ToString();
        }

        public override string GetDigitalStats(int ADBits, double ADHighVoltage, double ADLowVoltage)
        {
            StringBuilder gaussianString = new StringBuilder();

            Converter converter = new Converter(ADBits, ADHighVoltage, ADLowVoltage);
            
            gaussianString.AppendFormat("{0}:\t\t{1:0} @ {2:0.00} ns\n",
                                        "Peak", 
                                        converter.AnalogToDigital(m_Peak.Y), m_Peak.X);
            gaussianString.AppendFormat("{0}:\t{1:0} @ {2:0.00} ns\n",
                                        "T50 Raise", 
                                        converter.AnalogToDigital(m_T50Raise.Y), m_T50Raise.X);
            gaussianString.AppendFormat("{0}:\t\t{1:0} @ {2:0.00} ns\n",
                                        "T50 Fall", 
                                        converter.AnalogToDigital(m_T50Fall.Y), m_T50Fall.X);

            gaussianString.Append(GetTOFAndAreaStats());

            return gaussianString.ToString();
        }

        private string GetTOFAndAreaStats()
        {
            StringBuilder TOFAndAreaStats = new StringBuilder();

            TOFAndAreaStats.AppendFormat("{0}:\t\t{1:0.00} ns\n",
                                        "TOF",
                                        m_T50Fall.X - m_T50Raise.X);
            TOFAndAreaStats.AppendFormat("{0}:\t\t{1:0.00}\n",
                                        "Area", Area);
            TOFAndAreaStats.AppendFormat("{0}:\t{1:0.00}\n",
                                        "Area/1024", Area / 1024);

            return TOFAndAreaStats.ToString();
        }

        #endregion Stats
    }
}
