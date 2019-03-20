


namespace TesoApp.Business.Services
{
    using System.Linq;
    using System.Threading.Tasks;
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

        public async Task<bool> Create(Employee employee)
        {
            return await this.employeeRepository.CreateAsync(employee);
        }

        public async Task<bool> Delete(Employee employee)
        {
            return await this.employeeRepository.DeleteAsync(employee,true);
        }

        public IQueryable<Employee> GetAllEmployee()
        {
            return this.employeeRepository.GetAll();
        }

        public IQueryable<Employee> GetAllEmployeeByServiceType(int ServiceTypeId)
        {
            return this.employeeRepository.GetAllEmployeeByServiceTypeInclude(ServiceTypeId,c=>c.Occupation);
        }

        public Task<Employee> Login(string user, string pass)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}
