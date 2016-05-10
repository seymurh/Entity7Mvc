using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Entity7Mvc.Startup))]
namespace Entity7Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
