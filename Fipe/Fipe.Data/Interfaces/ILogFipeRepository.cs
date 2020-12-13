using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Data.Interfaces
{
    public interface ILogFipeRepository
    {

        Task GravarLog(string tipoExcecao, string mensagemExcecao, string rastreamento, DateTime dataExcecao);
    }
}
