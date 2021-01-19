using Fipe.Application.Interfaces;
using Fipe.Data.Entities;
using Fipe.Data.Interfaces;
using Fipe.Generics.Factory.Interface;
using System;
using System.Threading.Tasks;

namespace Fipe.Application.Services
{
    public class FipeAppService : IFipeAppService
    {
        private readonly IVeiculoMarcaAppService _veiculoMarcaAppService;
        private readonly IMarcaAppService _marcaAppService;
        private readonly IFactory _factory;
        private readonly ILogFipeRepository _logFipeRepository;

        public FipeAppService(IMarcaAppService marcaAppService, IVeiculoMarcaAppService veiculoMarcaAppService, IFactory factory, ILogFipeRepository logFipeRepository)
        {
            _marcaAppService = marcaAppService;
            _veiculoMarcaAppService = veiculoMarcaAppService;
            _factory = factory;
            _logFipeRepository = logFipeRepository;
        }

        public async Task PopularDadosObtidosApiFipeAsync()
        {
            try
            {
                await _marcaAppService.PopularMarcasObtidasApiFipeAsync();
                await _veiculoMarcaAppService.PopularVeiculosMarcaObtidosApiFipeAsync();
            }
            catch(Exception ex)
            {
                var log = _factory.GetFactory<LogFipe>();
                log.DataExcecao = DateTime.Now;
                log.MensagemExcecao = ex.Message;
                log.Rastreamento = ex.StackTrace;
                log.TipoExcecao = ex.GetType().Name;
                await _logFipeRepository.GravarLogAsync(log);
            }
        }
    }
}
