using Fipe.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fipe.Api.Controllers
{
    [Route("api/[controller]")]
    public class FipeController : Controller
    {
        private readonly IFipeAppService _fipe;

        public FipeController(IFipeAppService fipe)
        {
            _fipe = fipe;
        }

        [HttpPost]
        [Route("popularDadosFipe")]
        public async Task PopularDadosFipe()
        {
            await _fipe.PopularDadosObtidosApiFipeAsync();
        }
    }
}
