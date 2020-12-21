using Fipe.Data.Context;
using Fipe.Data.Entities;
using Fipe.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fipe.Data.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly FipeContext _context;

        public MarcaRepository(FipeContext context)
        {
            _context = context;
        }

        public async Task GravarMarcasAsync(IEnumerable<Marca> marcas)
        {
            await _context.SaveChangesListAsync(marcas);
        }

        public async Task<IEnumerable<Marca>> BuscarMarcasPorMesAnoReferenciaAsync(Expression<Func<Marca, bool>> expression)
        {
            return await _context.Marcas.Where(expression).ToListAsync();
        }

        public async Task<string> ObterDescricaoTipoVeiculoAsync(int idTipoVeiculo)
        {
            return await _context.Marcas.Where(marca => marca.IdTipoVeiculo == idTipoVeiculo)
                                            .Select(tipoVeiculo => tipoVeiculo.TipoVeiculo.Descricao)
                                            .FirstOrDefaultAsync();
        }
    }
}
