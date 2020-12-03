using Fipe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Data.Interfaces
{
    public interface IMarcaRepository
    {
        Task GravarMarcasAsync(IEnumerable<Marca> marcas);
    }
}
