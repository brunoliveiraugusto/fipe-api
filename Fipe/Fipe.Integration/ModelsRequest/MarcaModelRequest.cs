using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fipe.Integration.ModelsRequest
{
    public class MarcaModelRequest
    {
        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("fipe_name")]
        public string NomeFipe { get; set; }

        [JsonProperty("order")]
        public int OrderFipe { get; set; }

        [JsonProperty("key")]
        public string Chave { get; set; }

        [JsonProperty("id")]
        public int IdMarcaFipe { get; set; }

        [JsonIgnore]
        public int IdTipoVeiculo { get; set; }
    }
}
