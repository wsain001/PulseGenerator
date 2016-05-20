using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Digital_Pulse_Generator.WaveCalculator
{
    class TriangleWave : Wave
    {
        private double m_Area;
        private PointPair m_LowPeak;

        public TriangleWave()
        {
        }

        public TriangleWave(double amplititude, double period, int harmonic, double samplingInterval)
        {
            Calculate(amplititude, period, harmonic, samplingInterval);
        }

        public void Calculate(double amplitude, double period, int harmonic, double samplingInterval)
        {
            // Initialize member variables
            m_PointsList = new PointPairList();
            m_Peak = null;
            m_LowPeak = null;
            m_Area = 0;

            double x;
            double y;
            double frequency = 1 / period; // frequency = (1 / period)

            // calculate y for each sampling interval
            for (x = 0; x <= period; x += samplingInterval)
            {
                // Calculate y
                y = Summation(harmonic, x, frequency, amplitude);

                // Add values to point pair list
                m_PointsList.Add(x, y);

                // Calculate peaks
                CalculatePeaks(x, y);
            }

            // Calculate the area using the Riemann sum
            m_Area = (m_Peak.X * m_Peak.Y) * 2;

        }

        private double Summation(int harmonic, double x, double frequency, double amplitude)
        {
            double sum = 0;
            double angularFrequency = 2 * Math.PI * frequency;
            double front = 8 / Math.Pow(Math.PI, 2);

            for (int k = 0; k <= harmonic; k++)
            {
                double negative = Math.Pow(-1, k);
                int TwoKPlus1 = ((2 * k) + 1);
                double sinContent = (TwoKPlus1 * angularFrequency * x);
                double numerator = amplitude * Math.Sin(sinContent);
                double denominator = Math.Pow(TwoKPlus1, 2);

                sum += negative * numerator / denominator;
            }
                        
            return front * sum;
        }

        private void CalculatePeaks(double x, double y)
        {
            // Get the high and low peaks of this sine wave.
            if (x == 0)
            {
                m_Peak = m_PointsList[0];
                m_LowPeak = m_PointsList[0];
            }
            else
            {
                if (m_Peak.Y < y)
                {
                    m_Peak = m_PointsList[m_PointsList.Count - 1];
                }

                if (m_LowPeak.Y > y)
                {
                    m_LowPeak = m_PointsList[m_PointsList.Count - 1];
                }
            }
        }

        #region Stats

        public override string GetAnalogStats()
        {
            StringBuilder triangleString = new StringBuilder();

            triangleString.AppendFormat("{0}:\t{1:0.00} V @ {2:0.00} ns\n",
                                        "High Peak", m_Peak.Y, m_Peak.X);

            triangleString.AppendFormat("{0}:\t{1:0.00} V @ {2:0.00} ns\n",
                                        "Low Peak", m_LowPeak.Y, m_LowPeak.X);

            triangleString.Append(GetAreaString());

            return triangleString.ToString();
        }

        public override string GetDigitalStats(int ADBits, double ADHighVoltage, double ADLowVoltage)
        {
            Converter converter = new Converter(ADBits, ADHighVoltage, ADLowVoltage);

            StringBuilder triangleString = new StringBuilder();

            triangleString.AppendFormat("{0}:\t{1:0} @ {2:0.00} ns\n",
                                        "High Peak", converter.AnalogToDigital(m_Peak.Y), m_Peak.X);

            triangleString.AppendFormat("{0}:\t{1:0} @ {2:0.00} ns\n",
                                        "Low Peak", converter.AnalogToDigital(m_LowPeak.Y), m_LowPeak.X);

            triangleString.Append(GetAreaString());

            return triangleString.ToString();
        }

        private string GetAreaString()
        {
            return string.Format("{0}:\t\t{1:0.00}\n", "Area", m_Area);
        }

        #endregion Stats
    }
}
