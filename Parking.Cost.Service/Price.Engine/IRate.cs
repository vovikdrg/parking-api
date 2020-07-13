namespace Price.Engine
{
    public interface IRate
    {
        string Name { get; }
        decimal Price { get;  }
    }
}