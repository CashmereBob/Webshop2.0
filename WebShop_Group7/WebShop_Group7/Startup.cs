using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShop_Group7.Startup))]
namespace WebShop_Group7
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
