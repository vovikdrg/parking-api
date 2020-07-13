using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;

namespace Price.Engine
{
    public class PriceEngine : IPriceEngine
    {
        internal List<IRate> Rates = new List<IRate>();

        public decimal Evaluate(PriceRequest request)
        {
            var flatRate = Rates
                .OfType<FlatRate>()
                .Select(r => CalculateFlat(r, request))
                .Where(r => r.cost.HasValue)
                .OrderBy(c=>c.order)
                .ToList();
            if (flatRate.Any())
            {
                return flatRate.First().cost.Value;
            }
            var totalHours = Math.Round((request.Exit - request.Enter).TotalMinutes / 60, 2);
            return Rates
                .OfType<HourlyRate>()
                .Where(r=>r.MinHours < totalHours && r.MaxHours >= totalHours)
                .Select(r=>CalculateHourly((decimal)totalHours, request, r))
                .DefaultIfEmpty()
                .Min();
        }

        private (int order, decimal? cost) CalculateFlat(FlatRate flatRate, PriceRequest request)
        {
            if (request.Enter.TimeOfDay >= flatRate.Enter.from && request.Enter.TimeOfDay <= flatRate.Enter.to &&
                request.Exit.TimeOfDay >= flatRate.Leave.from && request.Exit.TimeOfDay <= flatRate.Leave.to
                && (!flatRate.Days.Any() || (flatRate.Days.Contains(request.Enter.DayOfWeek) && flatRate.Days.Contains(request.Exit.DayOfWeek))))
            {
                return (flatRate.Order, flatRate.Price);
            }
            return (0, null);
        }

        private decimal CalculateHourly(decimal totalHours, PriceRequest request, HourlyRate rate)
        {
            return rate.RechargePeriodHours.HasValue
                ? rate.Price * Math.Ceiling(totalHours / rate.RechargePeriodHours.Value)
                : rate.Price;
        }
    }
}