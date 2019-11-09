using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DM2.Startup))]
namespace DM2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
