using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AreasMVC.Startup))]
namespace AreasMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
