using Fipe.Data.Context;
using Fipe.Data.Entities;
using Fipe.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Data.Repository
{
    public class ParametroRepository : IParametroRepository
    {
        private readonly FipeContext _context;

        public ParametroRepository(FipeContext context)
        {
            _context = context;
        }

        public async Task<Parametro> ObterParametroPorDescricaoAsync(string descricao)
        {
            return await _context.Parametros.FirstOrDefaultAsync(parametro => parametro.NomeParametro == descricao && parametro.Ativo);
        }

        public async Task<string> ObterValorParametroPorDescricaoAsync(string descricao)
        {
            return await _context.Parametros.Where(parametro => parametro.NomeParametro == descricao && parametro.Ativo).Select(valor => valor.Valor).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<string>> ObterValorParametroAsync(Expression<Func<Parametro, bool>> expression)
        {
            return await _context.Parametros.Where(expression).Select(valor => valor.Valor).ToListAsync();
        }

        public async Task<IEnumerable<Parametro>> ObterParametrosAsync(Expression<Func<Parametro, bool>> expression)
        {
            return await _context.Parametros.Where(expression).ToListAsync();
        }
    }
}
