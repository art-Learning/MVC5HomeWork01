using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5HomeWork01.Startup))]
namespace MVC5HomeWork01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
