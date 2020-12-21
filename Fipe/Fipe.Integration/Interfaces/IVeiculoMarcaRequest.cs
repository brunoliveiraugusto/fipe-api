using Fipe.Integration.ModelsRequest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fipe.Integration.Interfaces
{
    public interface IVeiculoMarcaRequest
    {
        Task<IEnumerable<VeiculoMarcaModelRequest>> ObterVeiculosMarcaFipeApiAsync(string baseUrl, string url);
    }
}
