using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCR;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestThermostat()
        {
            Thermostat t = new Thermostat();
            t.Increment();
            Assert.AreEqual(30, t.currentTemp);
        }

        [TestMethod]
        public void TestSetValues()
        {
            Thermostat t = new Thermostat();
            t.Increment();
            Assert.AreEqual(30, t.currentTemp);
            t.max = 5;
            t.min = 35;
            t.currentTemp = 55;
            Assert.IsTrue(t.max > t.min,
        string.Format("max ({0}) isn't greater than min ({1})", t.max, t.min));
            Assert.IsTrue(t.currentTemp >= t.min, "temperature is below min");
            Assert.IsTrue(t.currentTemp <= t.max, "temperature is above max");
        }

    }
}
