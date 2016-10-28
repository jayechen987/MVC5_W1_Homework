using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientMangerSystem.Startup))]
namespace ClientMangerSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
