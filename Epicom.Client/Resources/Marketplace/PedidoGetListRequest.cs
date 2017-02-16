using System;
using System.Collections.Generic;
using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/pedidos?Criterio={Criterio}&DataInicio={DataInicio}&DataFim={DataFim}&Offset={Offset}&Limit={Limit}", "GET")]
    public class PedidoGetListRequest : PagedRequest, IResponse<IEnumerable<PedidoGetListResponse>>
    {
        /// <summary>
        /// Crit�rio de pesquisa
        /// </summary>
        public string Criterio { get; set; }

        /// <summary>
        /// Data de in�cio de per�odo para os pedidos
        /// </summary>
        public DateTime? DataInicio { get; set; }

        /// <summary>
        /// Data de fim de per�odo para os pedidos
        /// </summary>
        public DateTime? DataFim { get; set; }
    }
}