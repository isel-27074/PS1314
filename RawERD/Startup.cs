using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RawERD.Startup))]
namespace RawERD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app); 
        }
    }
}
