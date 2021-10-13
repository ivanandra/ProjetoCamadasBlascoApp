using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blasco.AppMVC.Startup))]
namespace Blasco.AppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
