using System.Collections.Generic;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Shared
{
	[Route("dummy", "GET")]
	public class VersionGetRequest : IResponse<string>
	{
	}
}
