using System;

namespace Fipe.Data.Entities
{
    public class Parametro
    {
        public int IdParametro { get; set; }
        public string NomeParametro { get; set; }
        public string Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public string Chave { get; set; }
    }
}
