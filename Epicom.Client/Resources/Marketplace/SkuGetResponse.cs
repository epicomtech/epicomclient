using System.Collections.Generic;
using Epicom.Client.Resources.Shared;

namespace Epicom.Client.Resources.Marketplace
{
    public class SkuGetResponse
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string NomeReduzido { get; set; }
        public string NomeReduzidoB2w { get; set; }
        public decimal Preco { get; set; }
        public decimal? PrecoDe { get; set; }
        public IEnumerable<ImagemGetResponse> Imagens { get; set; }
        public IEnumerable<GrupoGetResponse> Grupos { get; set; }
        public DimensoesGetResponse Dimensoes { get; set; }
        public IEnumerable<GrupoGetResponse.Atributo> Variacoes { get; set; }
        public bool Disponivel { get; set; }
        public int? Estoque { get; set; }
        public bool Ativo { get; set; }
        public string Ean { get; set; }
        public string Url { get; set; }
        public string CodigoCategoria { get; set; }
    }
}
