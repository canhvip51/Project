using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMSAdmin.Startup))]
namespace CMSAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
