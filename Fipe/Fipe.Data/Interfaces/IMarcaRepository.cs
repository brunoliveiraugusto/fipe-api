using Fipe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fipe.Data.Interfaces
{
    public interface IMarcaRepository
    {
        Task GravarMarcasAsync(IEnumerable<Marca> marcas);
        Task<IEnumerable<Marca>> BuscarMarcasPorMesAnoReferenciaAsync(Expression<Func<Marca, bool>> expression);
        Task<string> ObterDescricaoTipoVeiculoAsync(int idTipoVeiculo);
    }
}
