using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineCoaching.Startup))]
namespace OnlineCoaching
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
