using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DakwerkenRadino.StartUp))]

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
