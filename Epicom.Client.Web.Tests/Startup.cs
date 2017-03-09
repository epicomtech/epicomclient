using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Epicom.Client.Web.Tests.Startup))]
namespace Epicom.Client.Web.Tests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
