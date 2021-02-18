using System.Collections;

namespace Infrastructure.Caching
{
    public sealed class InMemoryCache : ICache
    {
        private InMemoryCache() { }

        private Hashtable _cache = new();

        public T GetValue<T>(string key)
        {
            if (string.IsNullOrEmpty(key) || !_cache.ContainsKey(key))
            {
                return default(T);
            }
            return (T)_cache[key];
        }

        public void SetValue<T>(string key, T value)
        {
            if (!string.IsNullOrEmpty(key))
            {
                _cache.Add(key, value);
            }
        }

        public static InMemoryCache Instance
        {
            get
            {
                return InMemoryCaching.instance;
            }
        }

        private class InMemoryCaching
        {
            internal static readonly InMemoryCache instance = new();
        }
    }
}
