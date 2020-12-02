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
        private readonly IParametroRepository _parametroRepository;
        private readonly IMarcaAppService _marcaAppService;

        public FipeAppService(IParametroRepository parametroRepository, IMarcaAppService marcaAppService)
        {
            _parametroRepository = parametroRepository;
            _marcaAppService = marcaAppService;
        }

        public Task PopularDadosObtidosApiFipeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
