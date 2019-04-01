using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UI.SP.Startup))]
namespace UI.SP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
