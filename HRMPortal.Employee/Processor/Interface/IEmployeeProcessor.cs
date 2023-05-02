using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Processor.Interface
{
    public interface IEmployeeProcessor
    {
        public Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        public Task<EmployeeDetail> GetEmployeeById(int emplyeeId);
        public Task<EmployeeDto> AddEmployee(EmployeeAddDto employeeDetails);
        public Task<EmployeeDetail> UpdateEmployee(EmployeeUpdateDto employeeDetailsUpdateDto, int employeeId);
        public  Task<bool> DeleteEmployee( int employeeId);
    }
}
