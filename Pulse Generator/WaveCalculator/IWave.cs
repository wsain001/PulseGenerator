using ZedGraph;

namespace Digital_Pulse_Generator
{
    interface IWave
    {
        PointPairList PointsList { get; }
        double Peak { get; }
        string GetAnalogStats();
        string GetDigitalStats(int ADBits, double ADHighVoltage, double ADLowVoltage);
    }
}
