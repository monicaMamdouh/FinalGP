using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GraduationProject2017.Startup))]
namespace GraduationProject2017
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
