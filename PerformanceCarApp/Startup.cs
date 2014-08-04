using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PerformanceCarApp.Startup))]
namespace PerformanceCarApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
