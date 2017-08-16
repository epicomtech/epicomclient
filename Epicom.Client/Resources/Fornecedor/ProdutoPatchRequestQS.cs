using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos2?codigo={Codigo}", "PATCH")]
    public class ProdutoPatchRequestQS : IEmptyResponse
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeReduzido { get; set; }
        public string Descricao { get; set; }
        public string CodigoCategoria { get; set; }
        public string CodigoMarca { get; set; }
        public string PalavrasChave { get; set; }
        public IEnumerable<GrupoPatchRequest> Grupos { get; set; }
    }
}
