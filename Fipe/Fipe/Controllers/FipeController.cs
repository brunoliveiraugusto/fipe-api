using Fipe.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fipe.Api.Controllers
{
    [ApiController]
    [Route("Api/Fipe")]
    public class FipeController : ControllerBase
    {
        private readonly IFipeAppService _fipe;

        public FipeController(IFipeAppService fipe)
        {
            _fipe = fipe;
        }

        /// <summary>
        /// Api para popular no banco de dados as informações de veículos trazidas da tabela Fipe.
        /// </summary>
        /// <response code="200">Indica que os dados foram registrados com sucesso</response>
        [HttpPost]
        [Route("PopularDadosFipe")]
        public async Task PopularDadosFipe()
        {
            await _fipe.PopularDadosObtidosApiFipeAsync();
        }
    }
}
