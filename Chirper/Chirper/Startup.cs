using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chirper.Startup))]
namespace Chirper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
