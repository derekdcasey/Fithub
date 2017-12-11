using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitHub.Startup))]
namespace FitHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
