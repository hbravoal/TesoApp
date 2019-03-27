using TesoApp.Common.Entities;
using TesoApp.Core.Contracts.EntityRepository;
using TesoApp.Core.DataContext;
using TesoApp.Core.Repository;

namespace TesoApp.Core.EntityRepository
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ServiceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
