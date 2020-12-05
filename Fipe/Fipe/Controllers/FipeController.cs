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

        [HttpPost]
        [Route("PopularDadosFipe")]
        public async Task PopularDadosFipe()
        {
            await _fipe.PopularDadosObtidosApiFipeAsync();
        }
    }
}
