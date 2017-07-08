using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public interface ICacheManager
    {
        TEntity Get<TEntity>(string key);

        void Set(string key, object value, TimeSpan cacheTime);

        bool Contains(string key);

        void Remove(string key);

        void Clear();
    }
}
