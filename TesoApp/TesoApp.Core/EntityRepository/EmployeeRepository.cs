namespace TesoApp.Core.EntityRepository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using TesoApp.Common.Entities;
    using TesoApp.Core.Contracts.EntityRepository;
    using TesoApp.Core.DataContext;
    using TesoApp.Core.Repository;

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IQueryable<Employee> GetAllEmployeeByServiceTypeInclude(int ServiceTypeId, params Expression<Func<Employee, object>>[] includeProperties)
        {
            IQueryable<Employee> queryable = this.applicationDbContext.Employees.Where(c=>c.OccupationId == ServiceTypeId);
            foreach (Expression<Func<Employee, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<Employee, object>(includeProperty);
            }
            return queryable;
        }
    }
}
