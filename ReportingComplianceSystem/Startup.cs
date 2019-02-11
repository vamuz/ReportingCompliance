using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReportingComplianceSystem.Startup))]
namespace ReportingComplianceSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
