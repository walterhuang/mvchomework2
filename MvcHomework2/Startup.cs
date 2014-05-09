using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcHomework2.Startup))]
namespace MvcHomework2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
