using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Salão.Startup))]
namespace Salão
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
