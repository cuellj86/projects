using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCR.Tests
{
    [TestClass()]
    public class ThermostatTests
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
            t.Max = 5;
            t.Min = 35;
            t.CurrentTemp = 55;
            Assert.IsTrue(t.Max > t.Min,
        string.Format("max ({0}) isn't greater than min ({1})", t.Max, t.Min));
            Assert.IsTrue(t.CurrentTemp >= t.Min, "temperature is below min");
            Assert.IsTrue(t.CurrentTemp <= t.Max, "temperature is above max");
        }

    }
}