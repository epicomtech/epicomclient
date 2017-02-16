using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{Codigo}", "GET")]
    public class ProdutoGetRequest : IResponse<ProdutoGetResponse>
    {
        public string Codigo { get; set; }
    }
}
