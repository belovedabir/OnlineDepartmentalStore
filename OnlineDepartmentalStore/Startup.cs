using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineDepartmentalStore.Startup))]
namespace OnlineDepartmentalStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
