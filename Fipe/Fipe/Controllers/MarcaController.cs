using Fipe.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost]
        [Route("PopularMarcasFipe")]
        public async Task PopularMarcasFipe()
        {
            await _marcaAppService.PopularMarcasObtidasApiFipeAsync();
        }
    }
}
