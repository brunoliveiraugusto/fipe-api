using Fipe.Integration.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Integration.Request
{
    public class MarcaRequest : BaseRequest, IMarcaRequest
    {
        public IEnumerable<MarcaModelRequest> Marcas { get; set; }

        public async Task<IEnumerable<MarcaModelRequest>> ObterMarcasFipeApi(string baseUrl, string url)
        {
            return await GetRequestListAsync<MarcaModelRequest>(baseUrl, url);
        }
    }
}
