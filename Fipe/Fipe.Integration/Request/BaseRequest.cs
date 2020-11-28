using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Integration.Request
{
    public abstract class BaseRequest
    {
        public abstract Task<T> GetRequestAsync<T>();
        public abstract IEnumerable<Task<T>> GetRequestListAsync<T>();
    }
}
