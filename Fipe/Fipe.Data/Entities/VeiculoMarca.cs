namespace Fipe.Data.Entities
{
    public class VeiculoMarca
    {
        public int IdVeiculoMarca { get; set; }
        public string FipeMarca { get; set; }
        public string Nome { get; set; }
        public string FipeMarcaApi { get; set; }
        public string Chave { get; set; }
        public string IdFipe { get; set; }
        public string FipeNome { get; set; }
        public string MesReferencia { get; set; }
        public string AnoReferencia { get; set; }
        public int IdMarca { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
