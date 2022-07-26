using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(string Key, object value, int duration)
        {
            _memoryCache.Set(Key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string Key)
        {
            return _memoryCache.Get<T>(Key);
        }

        public object Get(string Key)
        {
            return Get<object>(Key);
        }

        public bool isAdd(string Key)
        {
            return _memoryCache.TryGetValue(Key, out _);
        }

        public void Remove(string Key)
        {
            _memoryCache.Remove(Key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheExtriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheExtriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var keyToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keyToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
