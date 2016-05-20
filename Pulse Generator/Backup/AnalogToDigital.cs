using System;

namespace Digital_Pulse_Generator
{
    class Converter
    {
        public Converter()
        {
        }

        public Converter(int ADBits, double ADHighVoltage, double ADLowVoltage)
        {
            this.ADBits = ADBits;
            this.ADHighVoltage = ADHighVoltage;
            this.ADLowVoltage = ADLowVoltage;
        }

        #region non-static members

        #region properties

        public int ADBits { get; set; }
        public double ADHighVoltage { get; set; }
        public double ADLowVoltage{ get; set; }

        #endregion properties

        #region public methods

        public int AnalogToDigital(double voltage)
        {
            return AnalogToDigital(voltage, ADBits, ADHighVoltage, ADLowVoltage);
        }

        public double DigitalToAnalog(int digitalValue)
        {
            return DigitalToAnalog(digitalValue);
        }

        #endregion public methods

        #endregion non-static members


        #region static members

        public static int AnalogToDigital(double voltage, int ADBits, double ADHighVoltage, double ADLowVoltage)
        {
            int digitalValue;

            if (voltage < ADLowVoltage)
            {
                digitalValue = 0;
            }
            else if (voltage > ADHighVoltage)
            {
                digitalValue = (int)Math.Pow(2, ADBits);
            }
            else
            {
                digitalValue = (int)((Math.Pow(2, ADBits) * (voltage - ADLowVoltage)) / (ADHighVoltage - ADLowVoltage));
            }

            return digitalValue;
        }

        public static double DigitalToAnalog(int digitalValue, int ADBits, double ADHighVoltage, double ADLowVoltage)
        {
            return (digitalValue * (ADHighVoltage - ADLowVoltage) / Math.Pow(2, ADBits)) + ADLowVoltage;
        }

        #endregion static members
    }
}
