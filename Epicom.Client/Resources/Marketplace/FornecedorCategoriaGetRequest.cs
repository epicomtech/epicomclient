using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/fornecedores/categorias/{Id}", "GET")]
    public class FornecedorCategoriaGetRequest : IResponse<FornecedorCategoriaGetResponse>
    {
        public int Id { get; set; }
    }
}