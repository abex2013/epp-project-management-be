using Excellerent.APIModularization;
using Excellerent.Timesheet.Domain.Interfaces.Repository;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Services;
using Excellerent.Timesheet.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Excellerent.Timesheet.Presentation
{
    public class TimesheetModuleRegistration : ModuleStartup
    {
        public override void ConfigureDependencyInjection(IServiceCollection services)
        {

            services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();
            services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();
            services.AddScoped<ITimeSheetService, TimeSheetService>();
            services.AddScoped<ITimeEntryService, TimeEntryService>();
            services.AddScoped<IProjectMockService, ProjectMockService>();
            services.AddScoped<IClientMockService, ClientMockService>();
            services.AddScoped<IEmployeeMockService, EmployeeMockService>();
            services.AddScoped<ITimesheetAprovalRepository, TimesheetAprovalRepository>();
            services.AddScoped<ITimesheetAprovalService, TimesheetAprovalService>();
            services.AddScoped<ITimeEntryValidation, TimeEntryValidation>();

        }
    }
}
