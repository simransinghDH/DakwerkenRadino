using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DakwerkenRadino.Startup))]
namespace DakwerkenRadino
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
