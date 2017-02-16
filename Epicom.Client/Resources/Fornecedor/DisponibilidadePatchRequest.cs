using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{CodigoProduto}/skus/{CodigoSku}/disponibilidades/{CodigoMarketplace}?forceReprocessing={ForceNotificationPush}", "PATCH")]
    public class DisponibilidadePatchRequest : IEmptyResponse
    {
        public string CodigoProduto { get; set; }
        public string CodigoSku { get; set; }
        public decimal? PrecoDe { get; set; }
        public decimal? Preco { get; set; }
        public string CodigoMarketplace { get; set; }
        public bool? Disponivel { get; set; }
        /// <summary>
        /// Força o reenvio de notificações para SKUs que não foram alterados
        /// </summary>
        public bool ForceNotificationPush { get; set; }
    }
}
