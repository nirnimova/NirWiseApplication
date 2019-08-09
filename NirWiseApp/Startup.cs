using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NirWiseApp.Startup))]
namespace NirWiseApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
