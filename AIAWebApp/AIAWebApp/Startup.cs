using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AIAWebApp.Startup))]
namespace AIAWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
