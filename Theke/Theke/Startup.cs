using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Theke.Startup))]
namespace Theke
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
