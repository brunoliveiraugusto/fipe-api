using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Fipe.Integration.ModelsRequest
{
    public class VeiculoMarcaModelRequest
    {
        [JsonProperty("fipe_marca")]
        public string FipeMarca { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("marca")]
        public string FipeMarcaApi { get; set; }

        [JsonProperty("key")]
        public string Chave { get; set; }

        [JsonProperty("id")]
        public string IdFipe { get; set; }

        [JsonProperty("fipe_name")]
        public string FipeNome { get; set; }

        [JsonIgnore]
        public int IdMarca { get; set; }
    }
}
