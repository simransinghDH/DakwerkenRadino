using DakwerkenRadino;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StartUp))]

namespace DakwerkenRadino
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseHandler((request, response) => response.WriteAsync("OWIN Hello World"));
        }
    }
}
