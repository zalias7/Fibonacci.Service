namespace FibonacciRestApi.Abstractions
{
    public interface IFibonacciNumberCalculator
    {
        public Task<(int, int)> CalculateUsingFastDoubling(int n);
    }
}
