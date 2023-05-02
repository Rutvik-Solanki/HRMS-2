using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Engine.Interface
{
    public interface IEmployeeEngine
    {
        public Task<IEnumerable<EmployeeDetail>> GetAllEmployees();
        public Task<EmployeeDetail> GetEmployeeById(int emplyeeId);
        public Task<EmployeeDetail> AddEmployee(EmployeeDetail employeeDetail);
        public Task<EmployeeDetail> UpdateEmployee(EmployeeUpdateDto employeeDetailsUpdateDto, int employeeId);
        public  Task<bool> DeleteEmployee(int employeeId);
    }
}
