using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shrew.Web.Startup))]
namespace Shrew.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
