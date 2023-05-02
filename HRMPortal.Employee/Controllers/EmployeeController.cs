using HRMPortal.Employee.Models;
using HRMPortal.Employee.Processor.Class;
using HRMPortal.Employee.Processor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Controller
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeProcessor _employeeProcessor;

        public EmployeeController(IEmployeeProcessor employeeProcessor)
        {
            _employeeProcessor = employeeProcessor ?? throw new ArgumentNullException(nameof(employeeProcessor));
        }

        [HttpGet("allEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var getAllEmployee= await _employeeProcessor.GetAllEmployees();
            if(getAllEmployee!=null)
            {
                return Ok(getAllEmployee);
            }
            return BadRequest();
        }
        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            var getEmployee = await _employeeProcessor.GetEmployeeById(employeeId);
            if (getEmployee != null)
            {
                return Ok(getEmployee);
            }
            return BadRequest();
        }
        [HttpPost("AddEmployee")]

        public async Task<IActionResult> AddEmployee(EmployeeAddDto employeeAddDto)
        {
            var addEmployee = await _employeeProcessor.AddEmployee(employeeAddDto);
            if(addEmployee != null)
            {
                return Ok();
            }
            return BadRequest(addEmployee);
            
        }
        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeById(EmployeeUpdateDto employeeDetailsUpdateDto,int employeeId)
        {
            var updateEmployee = await _employeeProcessor.UpdateEmployee(employeeDetailsUpdateDto, employeeId);
            if(updateEmployee != null)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeById( int employeeId)
        {
            var deletEmployee = await _employeeProcessor.DeleteEmployee(employeeId);
            if (deletEmployee != null)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
