using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model.PreviousExprience;

namespace HRMPortal.Employee.Processor.Interface
{
    public interface IPreviousExprienceProcessor
    {
        Task<PreviousExprienceGetDto> GetPreviouesExprienceById(int EmployeeId, int PreviousExprienceId);
        Task<IEnumerable<PreviousExprienceGetDto>> GetPreviouesExprienceByEmployeeId(int EmployeeId);
        Task<PreviousExprienceAddDto> AddPreviouesExprience(int EmployeeId, PreviousExprienceAddDto previousExprience);
        Task<PreviousExprienceUpdateDto> UpdatePreviouesExprience(int EmployeeId, int PreviousExprienceId, PreviousExprienceUpdateDto previousExprienceUpdateDto);
        Task DeletePreviouesExprience(int EmployeeId, int PreviousExprienceId);
    }
}
