namespace FibonacciRestApi.Abstractions
{
    public interface IFibonacciNumberService
    {
        public Task<int> GetFibonacciNumber(int n);
    }
}
