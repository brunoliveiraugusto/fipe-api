﻿using Fipe.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fipe.Data.Interfaces
{
    public interface ITipoVeiculoRepository
    {
        Task<IEnumerable<TipoVeiculo>> ObterTiposVeiculoAsync();
    }
}
