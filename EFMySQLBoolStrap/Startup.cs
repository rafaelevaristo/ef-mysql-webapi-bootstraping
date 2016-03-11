using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFMySQLBoolStrap.Startup))]
namespace EFMySQLBoolStrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
