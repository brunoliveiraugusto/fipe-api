using System;
using System.Collections.Generic;
using System.Text;

namespace Fipe.Data.Entities
{
    public class TipoVeiculo
    {
        public int IdTipoVeiculo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual IEnumerable<Marca> Marcas { get; set; }
    }
}
