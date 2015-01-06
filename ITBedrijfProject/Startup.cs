using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITBedrijfProject.Startup))]
namespace ITBedrijfProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
