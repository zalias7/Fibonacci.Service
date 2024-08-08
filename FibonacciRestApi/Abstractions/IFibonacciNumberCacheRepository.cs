namespace FibonacciRestApi.Abstractions
{
    public interface IFibonacciNumberCacheRepository
    {
        public bool TryGetCachedValue(int n, out int number);
        public void InsertToCache(int n, int number);
    }
}