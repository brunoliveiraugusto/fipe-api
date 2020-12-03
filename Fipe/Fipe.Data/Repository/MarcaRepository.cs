﻿using Fipe.Data.Context;
using Fipe.Data.Entities;
using Fipe.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Data.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly FipeContext _context;

        public MarcaRepository(FipeContext context)
        {
            _context = context;
        }

        public async Task GravarMarcasAsync(IEnumerable<Marca> marcas)
        {
            _context.Add(marcas).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
    }
}