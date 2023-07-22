using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Presupuesto.Startup))]
namespace Presupuesto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
