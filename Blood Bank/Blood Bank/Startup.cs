using DataLayer;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(Blood_Bank.Startup))]
namespace Blood_Bank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // Database.SetInitializer<User>(null);
        }
    }
}
