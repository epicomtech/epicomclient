using System.Collections.Generic;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Shared
{
    [Route("shared/mapeamentos/categorias?codigoCategoria={CodigoCategoria}", "GET")]
    public class MapeamentoCategoriaGetRequest : IResponse<IEnumerable<MapeamentoCategoriaGetResponse>>
    {
        public string CodigoCategoria { get; set; }
    }
}