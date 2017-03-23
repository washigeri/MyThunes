using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyThunes.Startup))]
namespace MyThunes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
