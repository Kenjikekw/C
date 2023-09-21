using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pruebas.Startup))]
namespace Pruebas
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
