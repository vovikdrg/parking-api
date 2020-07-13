using System;
using NUnit.Framework;

namespace Price.Engine.Test
{
    public class HourlyRateTests
    {
        private PriceEngine _engine;
        [SetUp]
        public void Setup()
        {
            _engine = new DummyPriceEngineInitializer().Load();
        }

        [TestCase(1, 5.0)]
        [TestCase(2, 10)]
        [TestCase(3, 15)]
        [TestCase(5, 20)]
        [TestCase(48, 40)]
        [TestCase(240, 200)]
        public void Test1Hour(int hours, decimal expectedPrice)
        {
            var result = _engine.Evaluate(new PriceRequest(DateTime.UtcNow, DateTime.UtcNow.AddHours(hours)));
            Assert.AreEqual(expectedPrice, result);
        }


        [TestCase(58, 5.0)]
        [TestCase(110, 10)]
        [TestCase(160, 15)]
        [TestCase(360, 20)]
        [TestCase(2875, 40)] //TODO: I will calculate for 24 hours but is it right? Or idea is to take for each calendar day?
        [TestCase(14390, 200)]
        public void TestWithMinutes(int minutes, decimal expectedPrice)
        {
            var result = _engine.Evaluate(new PriceRequest(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(minutes)));
            Assert.AreEqual(expectedPrice, result);
        }
    }
}