using Microsoft.Owin;
using Owin;
using Reef.DAL;

[assembly: OwinStartupAttribute(typeof(Reef.Startup))]
namespace Reef
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            System.Data.Entity.Database.SetInitializer(new ReefKeeperInitializer());
            ReefKeeperDBContext db = new ReefKeeperDBContext();
            db.Database.Initialize(true);
            ConfigureAuth(app);
        }
    }
}
