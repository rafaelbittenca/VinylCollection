using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vinyl.UI.Startup))]
namespace Vinyl.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
