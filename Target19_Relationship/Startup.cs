using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Target19_Relationship.Startup))]
namespace Target19_Relationship
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
