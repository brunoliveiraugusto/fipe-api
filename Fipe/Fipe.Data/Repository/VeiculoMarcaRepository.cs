using Fipe.Data.Context;
using Fipe.Data.Entities;
using Fipe.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Data.Repository
{
    public class VeiculoMarcaRepository : IVeiculoMarcaRepository
    {
        private readonly FipeContext _context;

        public VeiculoMarcaRepository(FipeContext context)
        {
            _context = context;
        }

        public async Task GravarVeiculosMarcaAsync(IEnumerable<VeiculoMarca> veiculosMarca)
        {
            await _context.SaveChangesListAsync(veiculosMarca);
        }
    }
}
