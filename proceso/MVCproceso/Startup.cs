using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCproceso.Startup))]
namespace MVCproceso
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
