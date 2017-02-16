using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/marcas", "POST")]
    public class MarcaPostRequest : IEmptyResponse
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }        
    }
}
