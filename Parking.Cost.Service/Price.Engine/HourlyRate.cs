namespace Price.Engine
{
    public class HourlyRate : IRate
    {
        public HourlyRate(string name, int minHours, int maxHours, decimal price, int? rechargePeriodHours = null)
        {
            Name = name;
            MinHours = minHours;
            MaxHours = maxHours;
            Price = price;
            RechargePeriodHours = rechargePeriodHours;
        }

        public string Name { get; }
        public int MinHours { get; }
        public int MaxHours { get;  }
        public int? RechargePeriodHours { get; }
        public decimal Price { get;  }
    }
}