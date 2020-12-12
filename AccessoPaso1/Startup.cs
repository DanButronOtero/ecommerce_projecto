using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AccessoPaso1.Startup))]
namespace AccessoPaso1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
