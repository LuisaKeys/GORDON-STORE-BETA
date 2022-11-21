using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GORDON_STORE_ALPHA.Startup))]
namespace GORDON_STORE_ALPHA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
