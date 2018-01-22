using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/disponibilidades", "GET")]
    public class DisponibilidadeGetListRequest : IResponse<DisponibilidadeGetListResponse>
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
