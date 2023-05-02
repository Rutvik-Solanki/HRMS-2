using HRMPortal.Employee.Entity;
using HRMPortal.Employee.ErrorHandling;
using HRMPortal.Employee.Model.SalaryModel;
using HRMPortal.Employee.Repository;

namespace HRMPortal.Employee.Processor.Interface
{
    public interface ISalaryProcessor 
    {
        //Get
        Task<IEnumerable<Salary>> GetSalaryAsync();
        Task<SalaryDto> GetSalaryByIdAsysnc(int employeeId, int salaryId);
        Task<IEnumerable<SalaryDto>> GetSalaryByEmployeeIdAsysnc(int employeeId);
        Task<IEnumerable<Salary>> GetSalaryByBankDetailIdAsysnc(int bankDetailId);


        //Add
        Task<SalaryAddUpdateDto> AddSalaryAsync(int employeeId, SalaryAddUpdateDto salaryAddUpdateDto);

        //Update
        Task<SalaryAddUpdateDto> UpdateSalary(int employeeId,int salaryId, SalaryAddUpdateDto salaryAddUpdateDto);

        //Delete
        Task<bool> DeleteSalaryById(int employeeId,int salaryId);

    }
}
