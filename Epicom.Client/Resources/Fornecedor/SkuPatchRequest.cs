using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{CodigoProduto}/skus/{Codigo}?forceReprocessing={ForceNotificationPush}", "PATCH")]
    public class SkuPatchRequest : IEmptyResponse
    {
        public string CodigoProduto { get; set; }
        public string Codigo { get; set; }
        /// <summary>
        /// É utilizado como título das ofertas caso haja uma integração com o Mercado Livre.
        /// </summary>
        [MaxLength(60)]
        public string NomeReduzido { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string Ean { get; set; }

        /// <summary>
        /// Url do sku na loja virtual
        /// </summary>
        public string Url { get; set; }
        public bool? ForaDeLinha { get; set; }

        /// <summary>
        /// Estoque atual do sku. Pode ser deixado em branco caso o fornecedor não trabalhe
        /// com estoque conhecido.
        /// </summary>
        public int? Estoque { get; set; }
        public DimensoesRequest Dimensoes { get; set; }
        public IEnumerable<ImagemPatchRequest> Imagens { get; set; }
        public IEnumerable<GrupoPostRequest> Grupos { get; set; }
        /// <summary>
        /// Força o reenvio de notificações para SKUs que não foram alterados
        /// </summary>
        public bool ForceNotificationPush { get; set; }
    }
}
