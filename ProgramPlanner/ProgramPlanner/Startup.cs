using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgramPlanner.Startup))]
namespace ProgramPlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
