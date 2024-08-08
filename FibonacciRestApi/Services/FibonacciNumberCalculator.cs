using FibonacciRestApi.Abstractions;

namespace FibonacciRestApi.Services
{
    public class FibonacciNumberCalculator : IFibonacciNumberCalculator
    {
        public async Task<(int, int)> CalculateUsingFastDoubling(int n)
        {
            if (n == 0)
            {
                return (0, 1);
            }

            var (a, b) = await CalculateUsingFastDoubling(n >> 1);
            var c = a * ((b << 1) - a);
            var d = a * a + b * b;

            return (n & 1) == 1 ? (d,c + d) : (c,d);
        }
    }
}
