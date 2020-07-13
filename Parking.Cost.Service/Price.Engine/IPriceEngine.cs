using System.Linq.Expressions;

namespace Price.Engine
{
    public interface IPriceEngine
    {
        decimal Evaluate(PriceRequest request);
    }
}
