using System.Collections.Generic;
using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{CodigoProduto}/skus", "POST")]
    public class SkuPostRequest : IEmptyResponse
    {
        public string CodigoProduto { get; set; }
        public string Nome { get; set; }
        public string NomeReduzido { get; set; }
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        public string Ean { get; set; }

        /// <summary>
        /// Url do sku na loja virtual
        /// </summary>
        public string Url { get; set; }
        public bool? ForaDeLinha { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public DimensoesRequest Dimensoes { get; set; }
        public IEnumerable<ImagemPostRequest> Imagens { get; set; }
        public IEnumerable<GrupoPostRequest> Grupos { get; set; }
        public IEnumerable<GrupoGetResponse.Atributo> Variacoes { get; set; }

    }
}
