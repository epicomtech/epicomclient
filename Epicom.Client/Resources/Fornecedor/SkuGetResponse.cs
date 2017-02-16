using System.Collections.Generic;
using Epicom.Client.Resources.Shared;

namespace Epicom.Client.Resources.Fornecedor
{
    public class SkuGetResponse
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeReduzido { get; set; }
        public decimal Preco { get; set; }
        public IEnumerable<ImagemGetResponse> Imagens { get; set; }
        public IEnumerable<GrupoGetResponse> Grupos { get; set; }
        public bool Disponivel { get; set; }
        public int? Estoque { get; set; }
        public string Ean { get; set; }
        public SkuDimensoesGetResponse Dimensoes { get; set; }
    }

    public class SkuDimensoesGetResponse
    {
        public float? Altura { get; set; }
        public float? Largura { get; set; }
        public float? Comprimento { get; set; }
        public int? Peso { get; set; }
    }
}
