using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/produtos/{IdProduto}/skus/{Id}/disponibilidade", "GET")]
    public class DisponibilidadeGetRequest : IResponse<DisponibilidadeGetResponse>
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
    }
}
