using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/produtos/{Id}", "GET")]
    public class ProdutoGetRequest : IResponse<ProdutoGetResponse>
    {
        public int Id { get; set; }
    }
}
