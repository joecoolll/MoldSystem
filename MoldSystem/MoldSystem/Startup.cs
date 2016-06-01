using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoldSystem.Startup))]
namespace MoldSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
