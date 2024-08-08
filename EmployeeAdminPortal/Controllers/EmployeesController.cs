using EmployeeAdminPortal.Data;
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
    }
}
