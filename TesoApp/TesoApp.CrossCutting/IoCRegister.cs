namespace TesoApp.CrossCutting
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Core.DataContext;
    public class IoCRegister
    {
        public static IServiceCollection AddDbContext(IServiceCollection serviceDescriptors, string ConnectionString)
        {
            serviceDescriptors.AddDbContext<ApplicationDbContext>(config => {
                config.UseSqlServer(ConnectionString, d => d.MigrationsAssembly("TesoApp.API"));
            });
            return serviceDescriptors;
        }
    }
}
