using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Dtos.Employee;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private DataContext _datacontext;
        public EmployeesController(DataContext context)
        {
            _datacontext = context;
        }

        [HttpGet]
       
        public IActionResult GetAllEmployees()
        { 
            return Ok(_datacontext.Employees.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id) {
           var employee= _datacontext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto) {

            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };

            _datacontext.Employees.Add(employeeEntity);
            _datacontext.SaveChanges();
            return Ok(employeeEntity);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto employee )
        {
            var employeeDb = _datacontext.Employees.Find(id);
            if (employeeDb == null) { 
                return NotFound();
            }
            employeeDb.Name=employee.Name;
            employeeDb.Email=employee.Email;
            employeeDb.Phone=employee.Phone;
            employeeDb.Salary=employee.Salary;
            _datacontext.SaveChanges();
            return Ok(employeeDb);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _datacontext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            _datacontext.Employees.Remove(employee);
            _datacontext.SaveChanges();
            return Ok();
        }

    }
}
