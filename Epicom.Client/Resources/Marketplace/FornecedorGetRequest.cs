using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/fornecedores/{Id}", "GET")]
    public class FornecedorGetRequest : IResponse<FornecedorGetResponse>
    {
        public int Id { get; set; }
    }
}