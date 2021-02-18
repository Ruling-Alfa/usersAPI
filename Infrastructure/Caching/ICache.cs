using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Caching
{
    public interface ICache
    {
        public T GetValue<T>(string key);
        public void SetValue<T>(string key, T value);
    }
}
