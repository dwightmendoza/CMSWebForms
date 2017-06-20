using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMSWebForms.Startup))]
namespace CMSWebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
