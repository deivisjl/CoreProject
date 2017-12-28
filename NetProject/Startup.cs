using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetProject.Startup))]
namespace NetProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
