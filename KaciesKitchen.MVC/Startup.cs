using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KaciesKitchen.MVC.Startup))]
namespace KaciesKitchen.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
