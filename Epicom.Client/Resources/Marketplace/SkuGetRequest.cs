using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/skus/{Id}", "GET")]
    public class SkuGetRequest : IResponse<SkuGetResponse>
    {
        public int Id { get; set; }
    }
}
