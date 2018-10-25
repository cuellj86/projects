using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCR
{
    public class Thermostat
    {
        private Temperature max;
        private Temperature currentTemp;
        private Temperature.TemperatureType temperatureType;

        private Temperature min;

        public Temperature Min
        {
            get { return min; }
            set
            {
                if ((value.TemperatureValue <= max.TemperatureValue) &
                                 (value.TemperatureValue <= currentTemp.TemperatureValue))
                    min = value;
            }
        }
        public Temperature Max
        {
            get { return max;}
            set { max = value; }
        }
        public Temperature CurrentTemp { get => currentTemp; }

        public Thermostat()
        {
            temperatureType = Temperature.TemperatureType.Fahrenheit;
            min.SetTemperature(0, temperatureType);
            max.SetTemperature(50, temperatureType);
            currentTemp.SetTemperature(25, temperatureType);
        }


        public void Increment()
        {
            if (currentTemp.TemperatureValue > max.TemperatureValue)
            {
                currentTemp = min;
            }
            else
                currentTemp.TemperatureValue += 5;
        }
        public void Decrement()
        {
            if (currentTemp.TemperatureValue > min.TemperatureValue)
            {
                currentTemp = min;
            }
            else
                currentTemp.TemperatureValue -= 5;
        }
        private double FtoC(int temp)
        {
            return 5 / 9.0 * (temp - 32);
        }

        public double GetMaxC()
        {
            return FtoC((int)max.TemperatureValue);
        }
        public double GetMaxF()
        {
            return max.TemperatureValue;
        }
    }
}
