using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Epicom.Client;
using Epicom.Client.Resources.Shared;

namespace Epicom.Client.Web.Tests.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Testing access to MHubAPI.";

			return View();
		}

		public async Task<ActionResult> Test(string url, string key, string secret)
		{
			ViewBag.Message = "Testing access to MHubAPI.";
			var client = new EpicomClient(key, secret, new Http.Client.RetryPolicyConfig { RetryCount = 2 }) { UriAsString = url };
			var result = await client.GetAsync(new VersionGetRequest());
			ViewBag.Result = "API Version: " + result;
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}