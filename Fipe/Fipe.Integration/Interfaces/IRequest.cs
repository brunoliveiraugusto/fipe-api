using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Integration.Interfaces
{
    public interface IRequest
    {
        abstract Task<T> GetRequestAsync<T>(string baseUrl, string url) where T : class;
        abstract Task<IEnumerable<T>> GetRequestListAsync<T>(string baseUrl, string url) where T : class;
    }
}
