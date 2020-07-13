using System;

namespace Price.Engine
{
    public class PriceRequest
    {
        public PriceRequest(DateTime enter, DateTime exit)
        {
            Enter = enter;
            Exit = exit;
        }
        public DateTime Enter { get; }
        public DateTime Exit { get; }
    }
}