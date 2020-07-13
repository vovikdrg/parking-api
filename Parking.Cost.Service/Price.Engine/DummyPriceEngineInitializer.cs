using System.Collections.Generic;

namespace Price.Engine
{
    public class DummyPriceEngineInitializer : IPriceEngineLoader
    {
        public PriceEngine Load()
        {
            return new PriceEngine()
            {
                Rates = new List<IRate>(new[]
                {
                    new HourlyRate("Standard 1 hour rate", 0, 1, 5),
                    new HourlyRate("Standard 2 hour rate", 1, 2, 10),
                    new HourlyRate("Standard 3 hour rate", 2, 3, 15),
                    new HourlyRate("Standard 3+ hour rate", 3, 9999999, 20, 24)
                })
            };
        }
    }
}