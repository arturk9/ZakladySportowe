using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zaklady.Startup))]
namespace Zaklady
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
