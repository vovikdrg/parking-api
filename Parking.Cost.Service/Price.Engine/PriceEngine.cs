using System;
using System.Collections.Generic;
using System.Linq;

namespace Price.Engine
{
    public class PriceEngine : IPriceEngine
    {
        internal List<IRate> Rates = new List<IRate>();

        public decimal Evaluate(PriceRequest request)
        {
            var totalHours = Math.Round((request.Exit - request.Enter).TotalMinutes / 60, 2);
            return Rates
                .OfType<HourlyRate>()
                .Where(r=>r.MinHours < totalHours && r.MaxHours >= totalHours)
                .Select(r=>CalculateHourly((decimal)totalHours, request, r))
                .DefaultIfEmpty()
                .Min();
        }

        private decimal CalculateHourly(decimal totalHours, PriceRequest request, HourlyRate rate)
        {
            return rate.RechargePeriodHours.HasValue
                ? rate.Price * Math.Ceiling(totalHours / rate.RechargePeriodHours.Value)
                : rate.Price;
        }
    }
}