using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Digital_Pulse_Generator.WaveCalculator
{
    class Wave : IWave
    {
        protected PointPairList m_PointsList;
        protected PointPair m_Peak;

        #region IWave Members

        public ZedGraph.PointPairList PointsList
        {
            get { return m_PointsList; }
        }

        public double Peak
        {
            get { return m_Peak.Y; }
        }

        public virtual string GetAnalogStats()
        {
            return "";
        }

        public virtual string GetDigitalStats(int ADBits, double ADHighVoltage, double ADLowVoltage)
        {
            return "";
        }

        #endregion IWave Members

        public Wave()
        {
            m_PointsList = new PointPairList();
        }

    }
}
