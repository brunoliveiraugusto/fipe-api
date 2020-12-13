using Fipe.Data.Context;
using Fipe.Data.Entities;
using Fipe.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace Fipe.Data.Repository
{
    public class LogFipeRepository : ILogFipeRepository
    {
        private readonly FipeContext _context;

        public LogFipeRepository(FipeContext context)
        {
            _context = context;
        }

        public async Task GravarLog(string tipoExcecao, string mensagemExcecao, string rastreamento, DateTime dataExcecao)
        {
            throw new NotImplementedException();
        }
    }
}
