using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AIAWebApplication_2.Startup))]
namespace AIAWebApplication_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
