namespace TesoApp.Core.Contracts.EntityRepository
{
    using Common.Entities;
    using Repository;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IEmployeeRepository: IGenericRepository<Employee>
    {
        IQueryable<Employee> GetAllEmployeeByServiceTypeInclude(int ServiceTypeId, params Expression<Func<Employee, object>>[] includeProperties);
    }
}
