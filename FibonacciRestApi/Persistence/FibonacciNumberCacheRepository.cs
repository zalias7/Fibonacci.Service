using FibonacciRestApi.Abstractions;

namespace FibonacciRestApi.Persistence
{
    public class FibonacciNumberCacheRepository: IFibonacciNumberCacheRepository
    {
        private readonly Dictionary<int, int> _cache = new()
        {
            [0] = 1,
            [1] = 1
        };

        private ILogger<FibonacciNumberCacheRepository> logger;

        public FibonacciNumberCacheRepository(ILogger<FibonacciNumberCacheRepository> logger) 
        {
            this.logger = logger;
        }

        public bool TryGetCachedValue(int n, out int number)
        {
            var doesExist = _cache.TryGetValue(n, out number);
            return doesExist;
        }

        public void InsertToCache(int n, int number)
        {
            var wasAdded = _cache.TryAdd(n, number);
            if (wasAdded)
            {
                logger.LogInformation($"{number} was succesfully added to Fibonacci cache, with key: {n}");
            }
            else
            {
                logger.LogInformation($"{number} was already added to Fibonacci cache, with key: {n}");
            }
        }
    }
}
