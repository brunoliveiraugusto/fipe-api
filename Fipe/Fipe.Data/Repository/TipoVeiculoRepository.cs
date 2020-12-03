using Fipe.Data.Context;
using Fipe.Data.Entities;
using Fipe.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fipe.Data.Repository
{
    public class TipoVeiculoRepository : ITipoVeiculoRepository
    {
        private readonly FipeContext _context;

        public TipoVeiculoRepository(FipeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoVeiculo>> ObterTiposVeiculoAsync()
        {
            return await _context.TiposVeiculo.ToListAsync();
        }
    }
}
