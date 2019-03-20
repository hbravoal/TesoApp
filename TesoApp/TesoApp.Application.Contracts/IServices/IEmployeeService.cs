namespace TesoApp.Application.Contracts.IServices
{
    using System.Linq;
    using System.Threading.Tasks;
    using Common.Entities;
    public interface IEmployeeService
    {
        IQueryable<Employee> GetAllEmployee();
        Task<bool> Create(Employee employee);
        Task<bool> Update(Employee employee);
        Task<bool> Delete(Employee employee);
        Task<Employee> Login(string user,string pass);
        IQueryable<Employee> GetAllEmployeeByServiceType(int ServiceTypeId);

    }
}
