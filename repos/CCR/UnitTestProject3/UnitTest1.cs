using CCR;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestThermostat()
        {
            Thermostat t = new Thermostat();
            t.Increment();
            Assert.AreEqual(30, t.CurrentTemp);
        }
        [TestMethod]
        public void TestSetValues()
        {
            Thermostat t = new Thermostat();
            t.Increment();
            Assert.AreEqual(30, t.CurrentTemp);
            //t.Max = 5;
            //t.Min = 35;
            t.Increment();
            Assert.IsTrue(t.Max.TemperatureValue > t.Min.TemperatureValue,
        string.Format("max ({0}) isn't greater than min ({1})", t.Max, t.Min));
            Assert.IsTrue(t.CurrentTemp.TemperatureValue >= t.Min.TemperatureValue, "temperature is below min");
            Assert.IsTrue(t.CurrentTemp.TemperatureValue <= t.Max.TemperatureValue, "temperature is above max");
        }
       // [TestMethod]
       // public void TestNewThermo()
       // {
       //     Thermostat t = new Thermostat(30,5);
        //    t.Increment();
        //    Assert.AreEqual(25, t.CurrentTemp);
       // }
        [TestMethod]
        public void TestDecrement()
        {
            Thermostat t = new Thermostat();
            t.Decrement();
            Assert.IsTrue(t.CurrentTemp.TemperatureValue <= t.Max.TemperatureValue, "temp is not right");
        }
        [TestMethod]
        public void TestTemperature()
        {
            Temperature temp = new Temperature(10.0, Temperature.TemperatureType.Celsius);
            Assert.AreEqual(10.0, temp.Celsius(), .1);
            Assert.AreEqual(283.1, temp.Kelvin(), .1);
            Assert.AreEqual(50.0, temp.Fahrenheit(), .1);
        }
    }
}
