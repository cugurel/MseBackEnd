using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string Key);
        Object Get(string Key);
        void Add(string Key, object value, int duration);
        bool isAdd(string Key);
        void Remove(string Key);
        void RemoveByPattern(string pattern);
    }
}
