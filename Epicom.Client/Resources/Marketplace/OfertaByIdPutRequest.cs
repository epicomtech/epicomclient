using System.Collections.Generic;
using Epicom.Http.Client.Annotations;
using Newtonsoft.Json;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/ofertas/{OfertaId}", "PUT")]
    public class OfertaByIdPutRequest : OfertaPutRequest
    {
        [JsonIgnore]
        public int OfertaId { get; set; }
    }
}
