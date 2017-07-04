using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoDtPaging.Startup))]
namespace DemoDtPaging
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
