using Fipe.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Data.Interfaces
{
    public interface ILogFipeRepository
    {

        Task GravarLogAsync(ILogFipe log);
    }
}
