using System;
using System.Collections.Generic;
using System.Text;

namespace Fipe.Data.Entities
{
    public class LogFipe
    {
        public int IdLogFipe { get; set; }
        public string TipoExcecao { get; set; }
        public string MensagemExcecao { get; set; }
        public string Rastreamento { get; set; }
        public DateTime DataExcecao { get; set; }
    }
}
