using Excellerent.APIModularization;
using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Services;
using Excellerent.ResourceManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Excellerent.ResourceManagement.Presentation.Config
{
    public class ResourceManagementModuleRegistration : ModuleStartup
    {


        public override void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IEmergencyContactRepository, EmergencyContactRepository>();
            services.AddScoped<IEmergencyContactService, EmergencyContactService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IAsyncPersonalAddressRepository, AsyncPersonalAddressRepository>();
            services.AddScoped<IAsyncEmergencyAddressRepository, AsyncEmergencyAddressRepository>();
            services.AddScoped<IPersonalAddressService, PersonalAddressService>();
            services.AddScoped<IEmergencyAddressService, EmergencyAddressService>();

            services.AddScoped<IFamilyDetailRepository, FamilyDetailRepository>();
            services.AddScoped<IFamilyMemberRepository, FamilyMemberRepository>();
            services.AddScoped<IFamilyDetailService, FamilyDetailService>();
            services.AddScoped<IFamilyMemberService, FamilyMemberService>();

        }
    }
}
