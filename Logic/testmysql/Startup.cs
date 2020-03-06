using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testmysql.Startup))]
namespace testmysql
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
