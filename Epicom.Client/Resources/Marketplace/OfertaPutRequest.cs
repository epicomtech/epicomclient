using System.Collections.Generic;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/ofertas", "PUT")]
    public class OfertaPutRequest : IEmptyResponse
    {
        public int SkuId { get; set; }
        public string Codigo { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public string Erro { get; set; }
        public IEnumerable<int> Pendencias { get; set; }
    }
}