using Fipe.Application.Interfaces;
using Fipe.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Application.Services
{
    public class FipeAppService : IFipeAppService
    {
        private readonly IVeiculoMarcaAppService _veiculoMarcaAppService;
        private readonly IMarcaAppService _marcaAppService;

        public FipeAppService(IMarcaAppService marcaAppService, IVeiculoMarcaAppService veiculoMarcaAppService)
        {
            _marcaAppService = marcaAppService;
            _veiculoMarcaAppService = veiculoMarcaAppService;
        }

        public async Task PopularDadosObtidosApiFipeAsync()
        {
            try
            {
                await _marcaAppService.PopularMarcasObtidasApiFipeAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
