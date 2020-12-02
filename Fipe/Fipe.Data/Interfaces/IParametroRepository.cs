using Fipe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fipe.Data.Interfaces
{
    public interface IParametroRepository
    {
        Task<Parametro> ObterParametroPorDescricaoAsync(string descricao);
        Task<string> ObterValorParametroPorDescricaoAsync(string descricao);
        Task<IEnumerable<string>> ObterValorParametroExpressionAsync(Expression<Func<Parametro, bool>> expression);
    }
}
