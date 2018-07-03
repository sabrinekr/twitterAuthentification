using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(login33.Startup))]
namespace login33
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
