using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GruppG.Startup))]
namespace GruppG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
