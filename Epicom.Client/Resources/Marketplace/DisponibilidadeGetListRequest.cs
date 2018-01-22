using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/disponibilidades", "GET")]
    public class DisponibilidadeGetListRequest : IResponse<DisponibilidadeGetResponse>
    {
        public int DataInicio { get; set; }
        public int DataFim { get; set; }
    }
}
