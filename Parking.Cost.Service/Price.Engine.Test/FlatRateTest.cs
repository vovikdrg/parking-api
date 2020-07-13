using System;
using NUnit.Framework;

namespace Price.Engine.Test
{
    public class FlatRateTest
    {
        private PriceEngine _engine;
        [SetUp]
        public void Setup()
        {
            _engine = new DummyPriceEngineInitializer().Load();
        }
       
        [Test]
        public void TestEarlyBird()
        {
            var result = _engine.Evaluate(new PriceRequest(new DateTime(2020, 07, 13, 6, 0, 0), 
                new DateTime(2020, 07, 13, 16, 0, 0)));
            Assert.AreEqual(13, result);
        }

        [Test]
        public void TestNightRate()
        {
            var result = _engine.Evaluate(new PriceRequest(new DateTime(2020, 07, 13, 18, 0, 0), 
                new DateTime(2020, 07, 14, 16, 0, 0)));
            Assert.AreEqual(6.5, result);
        }

        [Test]
        public void TestWeeklyRate()
        {
            var result = _engine.Evaluate(new PriceRequest(new DateTime(2020, 07, 11, 0, 0, 0), 
                new DateTime(2020, 07, 12, 23, 0, 0)));
            Assert.AreEqual(10, result);
        }
    }
}