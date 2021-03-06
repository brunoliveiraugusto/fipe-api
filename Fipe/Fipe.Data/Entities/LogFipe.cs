﻿using Fipe.Data.Entities.Interfaces;
using System;

namespace Fipe.Data.Entities
{
    public class LogFipe : ILogFipe
    {
        public int IdLogFipe { get; set; }
        public string TipoExcecao { get; set; }
        public string MensagemExcecao { get; set; }
        public string Rastreamento { get; set; }
        public DateTime DataExcecao { get; set; }
    }
}
