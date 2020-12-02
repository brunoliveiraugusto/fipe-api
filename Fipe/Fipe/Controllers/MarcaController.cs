using Fipe.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Fipe.Api.Controllers
{
    [Route("api/marca")]
    public class MarcaController : Controller
    {
        private readonly IMarcaAppService _marcaAppService;

        public MarcaController(IMarcaAppService marcaAppService)
        {
            _marcaAppService = marcaAppService;
        }
    }
}
