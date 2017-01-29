using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserSystem.Web.Startup))]
namespace UserSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
