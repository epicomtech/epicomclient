using System.ComponentModel.DataAnnotations;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using Newtonsoft.Json;

namespace Epicom.Client.Resources.Shared
{
    [Route("shared/categorias/{Codigo}", "PATCH")]
    public class CategoriaPatchRequest : IEmptyResponse
    {
        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Nome { get; set; }

        public string CategoriaPai { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Associavel { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Ativo { get; set; }
    }
}