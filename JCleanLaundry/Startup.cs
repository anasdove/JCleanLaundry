using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JCleanLaundry.Startup))]
namespace JCleanLaundry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
