using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Digital_Pulse_Generator.WaveCalculator
{
    class SquareWave : Wave
    {
        private double m_Area;
        private PointPair m_LowPeak;        
        
        public SquareWave()
        {
        }

        public SquareWave(double amplititude, double period, double phase, double samplingInterval)
        {
            Calculate(amplititude, period, phase, 0, samplingInterval, false);
        }

        public SquareWave(double amplititude, double period, int harmonic, double samplingInterval)
        {
            Calculate(amplititude, period, 0, harmonic, samplingInterval, true);
        }

        public void Calculate(double amplititude, double period, double phase, int harmonic, double samplingInterval, bool useHarmonic)
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
                if (useHarmonic)
                {
                    y = CalculateYUsingHarmonics(harmonic, x, frequency, amplititude, phase);
                }
                else
                {
                    y = CalculateY(x, amplititude, frequency, phase);
                }

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
            // calculate y for a sine wave
            // y(x) = amplitude * sin((2 * PI * frequency * x) + phase)
            double y = amplititude * Math.Sin((2 * Math.PI * frequency * x) + phase);

            double roundedY = (Math.Round(y, 9));

            if (roundedY > 0)
                return amplititude;
            else if (roundedY < 0)
                return -1 * amplititude;
            else
                return 0;
        }

        private double CalculateYUsingHarmonics(int k, double x, double frequency, double amplitude, double phase)
        {
            double sum = 0;
            double sinContent = 0;
            double k_d = 0;
            double angular = 2 * Math.PI * frequency;
            
            double front = 4 / Math.PI;

            for (int i = 1; i <= k; i += 2)
            {
                k_d = i;
                                
                sinContent = (k_d * Math.PI * x) / (1 / frequency / 2);

                sum += amplitude * (1 / k_d) * Math.Sin(sinContent);
            }

            return front * sum;

        }

        #region Stats

        public override string GetAnalogStats()
        {
            StringBuilder stats = new StringBuilder();

            stats.AppendFormat("{0}:\t\t{1:0.00} V\n",
                                        "High Peak", m_Peak.Y);

            stats.AppendFormat("{0}:\t\t{1:0.00} V\n",
                                        "Low Peak", m_LowPeak.Y);

            stats.Append(GetAreaString());

            return stats.ToString();
        }

        public override string GetDigitalStats(int ADBits, double ADHighVoltage, double ADLowVoltage)
        {
            Converter converter = new Converter(ADBits, ADHighVoltage, ADLowVoltage);

            StringBuilder stats = new StringBuilder();

            stats.AppendFormat("{0}:\t\t{1:0}\n",
                                "High Peak", converter.AnalogToDigital(m_Peak.Y));

            stats.AppendFormat("{0}:\t\t{1:0}\n",
                               "Low Peak", converter.AnalogToDigital(m_LowPeak.Y));

            stats.Append(GetAreaString());

            return stats.ToString();
        }

        private string GetAreaString()
        {
            return string.Format("{0}:\t{1:0.00} ns\n", "Area (Riemann sum)", m_Area);
        }

        #endregion Stats
    }
}
