using System;
using System.Collections.Generic;

namespace Price.Engine
{
    public class DummyPriceEngineInitializer : IPriceEngineLoader
    {
        public PriceEngine Load()
        {
            return new PriceEngine()
            {
                Rates = new List<IRate>(new IRate[]
                {
                    new HourlyRate("Standard 1 hour rate", 0, 1, 5),
                    new HourlyRate("Standard 2 hour rate", 1, 2, 10),
                    new HourlyRate("Standard 3 hour rate", 2, 3, 15),
                    new HourlyRate("Standard 3+ hour rate", 3, 9999999, 20, 24),
                    new FlatRate("Early Bird", 13, 
                        (new TimeSpan(6,0, 0), new TimeSpan(9, 0,0)),
                        (new TimeSpan(15, 30, 0), new TimeSpan(23, 30, 0)), 20),
                    new FlatRate("Night Rate", 6.50m, (new TimeSpan(18, 0, 0), new TimeSpan(23, 59, 59)),
                        (new TimeSpan(15, 30, 0), new TimeSpan(23, 30, 0)), 20), 
                    new FlatRate("Weekend rate", 10, (new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59)),
                        (new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59)), 10,new [] {DayOfWeek.Saturday, DayOfWeek.Sunday}), 
                })
            };
        }
    }
}