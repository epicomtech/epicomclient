using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/disponibilidades?&DataInicio={DataInicio}&DataFim={DataFim}&Offset={Offset}&Limit={Limit}", "GET")]
    public class DisponibilidadeGetListRequest : PagedRequest, IResponse<IEnumerable<DisponibilidadeGetListResponse>>
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}