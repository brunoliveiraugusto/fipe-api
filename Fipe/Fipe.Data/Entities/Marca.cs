﻿namespace Fipe.Data.Entities
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string Nome { get; set; }
        public string NomeFipe { get; set; }
        public int OrderFipe { get; set; }
        public string Chave { get; set; }
        public int IdMarcaFipe { get; set; }
        public int TipoVeiculo { get; set; }
    }
}