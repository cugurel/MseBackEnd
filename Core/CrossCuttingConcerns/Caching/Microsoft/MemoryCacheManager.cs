using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            throw new NotImplementedException();
        }
    }
}
