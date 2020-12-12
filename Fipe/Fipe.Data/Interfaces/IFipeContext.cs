using Fipe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fipe.Data.Interfaces
{
    public interface IFipeContext
    {
        DbSet<Parametro> Parametros { get; set; }
        DbSet<Marca> Marcas { get; set; }
        DbSet<TipoVeiculo> TiposVeiculo { get; set; }
        DbSet<LogFipe> LogsFipe { get; set; }

    }
}
