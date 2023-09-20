using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuickPharm360.Startup))]
namespace QuickPharm360
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
