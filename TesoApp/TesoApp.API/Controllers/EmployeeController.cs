namespace TesoApp.API.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Application.Contracts.IServices;
    using TesoApp.Common.Entities;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        #region CRUD
        [HttpGet]
        public ActionResult<ICollection<Employee>> Get()
        {
            return this.employeeService.GetAllEmployee().ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            return Ok(await this.employeeService.Create(employee));
        }
        [HttpPut]
        public async Task<IActionResult> Put(Employee employee)
        {
            return Ok(await this.employeeService.Update(employee));
        }

        [HttpDelete]
        public async Task<IActionResult> Deletet(Employee employee)
        {
            return Ok(await this.employeeService.Delete(employee));
        } 
        #endregion

        [HttpGet("{id}")]
        [Route("GetByServiceType")]
        public ActionResult<ICollection<Employee>> GetByServiceType(int id)
        {
            return this.employeeService.GetAllEmployeeByServiceType(id).ToList();
        }
        
    }
}