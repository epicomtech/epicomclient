using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/marcas/{Codigo}", "GET")]
    public class MarcaGetRequest : IResponse<MarcaGetResponse>
    {
        public string Codigo { get; set; }
    }
}
