using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Discuzit.Startup))]
namespace Discuzit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
