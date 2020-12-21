using Fipe.Integration.Interfaces;
using Fipe.Integration.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fipe.Integration.Request
{
    public class VeiculoMarcaRequest : BaseRequest, IVeiculoMarcaRequest
    {
        public VeiculoMarcaRequest(HttpClient client) : base(client)
        {

        }

        public async Task<IEnumerable<VeiculoMarcaModelRequest>> ObterVeiculosMarcaFipeApiAsync(string baseUrl, string url)
        {
            return await GetRequestListAsync<VeiculoMarcaModelRequest>(baseUrl, url);
        }
    }
}
