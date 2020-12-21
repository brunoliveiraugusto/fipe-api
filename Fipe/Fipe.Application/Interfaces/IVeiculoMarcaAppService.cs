using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Application.Interfaces
{
    public interface IVeiculoMarcaAppService
    {
        Task PopularVeiculosMarcaObtidosApiFipeSync();
        string ObterTipoVeiculo(string descricao);
    }
}
