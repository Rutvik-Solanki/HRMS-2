using HRMPortal.Employee.Entity;
using HRMPortal.Employee.ErrorHandling;
using HRMPortal.Employee.Model;

namespace HRMPortal.Employee.Repository.Interface
{
    public interface ISalaryRepository 
    {
        

        //Get
        Task<IEnumerable<Salary>> GetSalaryAsync();
        Task<Salary> GetSalaryByIdAsysnc(int employeeId, int salaryId);
        Task<IEnumerable<Salary>> GetSalaryByEmployeeIdAsysnc(int employeeId);
        Task<IEnumerable<Salary>> GetSalaryByBankDetailIdAsysnc(int bankDetailId);


        //Add
        Task<Salary> AddSalaryAsync(int employeeId, Salary salary);
      

        //Update
        Task<Salary> UpdateSalary(Salary salary);
               
        //Delete
        void DeleteSalaryById(Salary salary);

      
    }

}
