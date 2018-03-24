using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blood_Bank.Startup))]
namespace Blood_Bank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
