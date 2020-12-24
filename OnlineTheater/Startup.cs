using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineTheater.Startup))]
namespace OnlineTheater
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
