using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Repository.Interface
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<EmployeeDetail>> GetAllEmployees();
        public Task<EmployeeDetail> GetEmployeeById(int emplyeeId);
        public Task<EmployeeDetail> AddEmployee(EmployeeDetail employeeDetail);
        public Task<EmployeeDetail> UpdateEmployee(EmployeeDetail employeeDetail);

        public Task<bool> DeleteEmployee(EmployeeDetail employeeDetail);
    }
}
