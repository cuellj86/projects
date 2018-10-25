using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCR
{
    public class Temperature
    {
        private double temperature;
        public TemperatureType Type { get; set; }
        public double TemperatureValue { get { return temperature; } set { temperature = value; } }

        public enum TemperatureType
        {
            Kelvin, Celsius, Fahrenheit
        }

        public Temperature(double temperature, TemperatureType type)
        {
            SetTemperature(temperature, type);
        }

        public void SetTemperature(double temperature, TemperatureType type)
        {
            this.temperature = temperature;
            this.Type = type;
        }

        public double Celsius()
        {
            double celsius = 0;
            TemperatureType type = TemperatureType.Celsius;
            switch (type)
            {
                case TemperatureType.Celsius:
                    celsius = temperature;
                    break;
                case TemperatureType.Fahrenheit:
                    celsius = temperature * (9 / 5) + 32;
                    break;
                case TemperatureType.Kelvin:
                    celsius = temperature + 273.15;
                    break;
            }
            return celsius;
        }
        public double Fahrenheit()
        {
            double fahrenheit = 0;
            TemperatureType type = TemperatureType.Celsius;
            switch (type)
            {
                case TemperatureType.Celsius:
                    fahrenheit = temperature * (9/5) + 40;
                    break;
                case TemperatureType.Fahrenheit:
                    fahrenheit = temperature;
                    break;
                case TemperatureType.Kelvin:
                    fahrenheit = (temperature + 459.67) * (5 / 9);
                    break;
            }
            return fahrenheit;
        }
        public double Kelvin()
        {
            double kelvin = 0;
            TemperatureType type = TemperatureType.Celsius;
            switch (type)
            {
                case TemperatureType.Celsius:
                    kelvin = temperature + 273.15;
                    break;
                case TemperatureType.Fahrenheit:
                    kelvin = temperature * (9 / 5) - 459.67;
                    break;
                case TemperatureType.Kelvin:
                    kelvin = temperature;
                    break;
            }
            return kelvin;
        }
    }
}
