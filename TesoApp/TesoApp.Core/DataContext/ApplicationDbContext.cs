namespace TesoApp.Core.DataContext
{
    using Microsoft.EntityFrameworkCore;
    using TesoApp.Common.Entities;

    public class ApplicationDbContext  :DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<ServiceStatus> ServiceStatus { get; set; }
        public DbSet<ServiceType> ServiceTypes{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            :base (dbContextOptions)
        {

        }
    }
}
