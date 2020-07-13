using System;
using System.Collections.Generic;

namespace Price.Engine
{
    public interface IRate
    {
        string Name { get; }
        decimal Price { get;  }
    }

    public class FlatRate : IRate
    {
        public FlatRate(string name, decimal price, (TimeSpan, TimeSpan) enter, (TimeSpan, TimeSpan) leave, int order, IEnumerable<DayOfWeek> days = null)
        {
            Name = name;
            Price = price;
            Enter = enter;
            Leave = leave;
            Order = order;
            Days = new List<DayOfWeek>(days ?? new DayOfWeek[0]);
        }

        public string Name { get; }
        public int Order { get; }
        public decimal Price { get; }
        public (TimeSpan from, TimeSpan to) Enter { get; }
        public (TimeSpan from, TimeSpan to) Leave { get; }
        public List<DayOfWeek> Days { get; }
    }
}