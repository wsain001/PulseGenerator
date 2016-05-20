using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Digital_Pulse_Generator.WaveCalculator
{
    class SineWave : Wave
    {
        private PointPair m_LowPeak;
        private double m_Area;

        public SineWave()
        {
        }

        public SineWave(double amplititude, double period, double phase, double samplingInterval)
        {
            Calculate(amplititude, period, phase, samplingInterval);
        }

        public void Calculate(double amplititude, double period, double phase, double samplingInterval)
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
                y = CalculateY(x, amplititude, frequency, phase);

                // Add values to point pair list
                m_PointsList.Add(x, y);

                // Calculate peaks
                CalculatePeaks(x, y);

                // Calculate the area using the Riemann sum
                m_Area += Math.Abs(y) * samplingInterval;
            }
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

        private double CalculateY(double x, double amplititude, double frequency, double phase)
        {
            // y(x) = amplitude * sin((2 * PI * frequency * x) + phase)
            return amplititude * Math.Sin((2 * Math.PI * frequency * x) + phase);
        }

        #region Stats

        public override string GetAnalogStats()
        {
            StringBuilder sineString = new StringBuilder();

            sineString.AppendFormat("{0}:\t\t{1:0.00} V @ {2:0.00} ns\n",
                                        "High Peak", m_Peak.Y, m_Peak.X);

            sineString.AppendFormat("{0}:\t\t{1:0.00} V @ {2:0.00} ns\n",
                                        "Low Peak", m_LowPeak.Y, m_LowPeak.X);

            sineString.AppendFormat(GetAreaString());

            return sineString.ToString();
        }

        public override string GetDigitalStats(int ADBits, double ADHighVoltage, double ADLowVoltage)
        {
            Converter converter = new Converter(ADBits, ADHighVoltage, ADLowVoltage);

            StringBuilder sineString = new StringBuilder();

            sineString.AppendFormat("{0}:\t\t{1:0} @ {2:0.00} ns\n",
                                        "High Peak", converter.AnalogToDigital(m_Peak.Y), m_Peak.X);

            sineString.AppendFormat("{0}:\t\t{1:0} @ {2:0.00} ns\n",
                                        "Low Peak", converter.AnalogToDigital(m_LowPeak.Y), m_LowPeak.X);

            sineString.AppendFormat(GetAreaString());
            
            return sineString.ToString();
        }

        private string GetAreaString()
        {
            return string.Format("{0}:\t{1:0.00} ns\n", "Area (Riemann sum)", m_Area);
        }

        #endregion Stats
    }
}
