using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtigoAreasMVC.Startup))]
namespace ArtigoAreasMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
