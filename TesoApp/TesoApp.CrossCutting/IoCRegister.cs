namespace TesoApp.CrossCutting
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Core.DataContext;
    using Application.Contracts.IServices;
    using Business.Services;
    using Core.Contracts.EntityRepository;
    using Core.EntityRepository;

    public class IoCRegister
    {
        public static IServiceCollection AddDbContext(IServiceCollection serviceDescriptors, string ConnectionString)
        {
            serviceDescriptors.AddDbContext<ApplicationDbContext>(config => {
                config.UseSqlServer(ConnectionString, d => d.MigrationsAssembly("TesoApp.API"));
            });
            return serviceDescriptors;
        }
        public static IServiceCollection AddServices(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IEmployeeService, EmployeeService>();
            return serviceDescriptors;
        }
        public static IServiceCollection AddRepository(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return serviceDescriptors;
        }
    }
}
