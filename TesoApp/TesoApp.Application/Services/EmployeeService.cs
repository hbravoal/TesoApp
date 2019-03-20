


namespace TesoApp.Application.Services
{
    using System.Linq;
    using Application.Contracts.IServices;
    using Common.Entities;
    using Core.Contracts.EntityRepository;
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public IQueryable<Employee> GetAllEmployee()
        {
            return this.employeeRepository.GetAll();
        }
    }
}
