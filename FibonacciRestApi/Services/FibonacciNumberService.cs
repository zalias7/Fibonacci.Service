using FibonacciRestApi.Abstractions;

namespace FibonacciRestApi.Services
{
    public class FibonacciNumberService : IFibonacciNumberService
    {
        private readonly IFibonacciNumberCacheRepository cacheRepository;
        private readonly IFibonacciNumberCalculator fibonacciNumberCalculator;

        public FibonacciNumberService(IFibonacciNumberCacheRepository cacheRepository,
            IFibonacciNumberCalculator fibonacciNumberCalculator)
        {
            this.cacheRepository = cacheRepository;
            this.fibonacciNumberCalculator = fibonacciNumberCalculator;
        }

        public async Task<int> GetFibonacciNumber(int n)
        {
            var doesExist = cacheRepository.TryGetCachedValue(n, out int number);
            if (doesExist)
            {
                return number;
            }
            (number, var nextNumber) = await fibonacciNumberCalculator.CalculateUsingFastDoubling(n);

            cacheRepository.InsertToCache(n, number);
            cacheRepository.InsertToCache(n + 1, nextNumber);

            return number;
        }
    }
}
