using Fipe.Integration.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Integration
{
    public interface IMarcaRequest
    {
        IEnumerable<MarcaModelRequest> Marcas { get; set; }
        Task<IEnumerable<MarcaModelRequest>> ObterMarcasFipeApi(string baseUrl, string url);
    }
}
