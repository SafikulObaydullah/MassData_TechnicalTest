using BMTLLMS.Service.Contracts;
using BMTLLMS.Service.Implementations;

namespace BMTLLMS.Web.DependencyInjection
{
    public static class Services
    {
        public static IFacadeRegistration Service { get; set; } = new FacadeRegistration();

        public static void RegisterDependencies(IServiceCollection services, string conStr)
        {
            Service.AddInfrastucture(services, conStr);
        }
    }
}
