using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusiSoft.Web.Startup))]
namespace MusiSoft.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
