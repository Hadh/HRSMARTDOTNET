using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRSmart.Startup))]
namespace HRSmart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
