using System.Collections.Generic;
using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos", "POST")]
    public class ProdutoPostRequest : IEmptyResponse
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeReduzido { get; set; }
        public string CodigoCategoria { get; set; }
        public string CodigoMarca { get; set; }
        public string Descricao { get; set; }
        public string PalavrasChave { get; set; }
        public string Genero { get; set; }

        public IEnumerable<GrupoPostRequest> Grupos { get; set; }
    }
}
