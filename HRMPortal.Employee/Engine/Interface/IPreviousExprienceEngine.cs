using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model;

namespace HRMPortal.Employee.Engine.Interface
{
    public interface IPreviousExprienceEngine
    {
        Task<PreviousExprience> GetPreviouesExprienceById(int EmployeeId, int PreviousExprienceId);
        Task<IEnumerable<PreviousExprience>> GetPreviouesExprienceByEmployeeId(int EmployeeId);
        Task<PreviousExprience> AddPreviouesExprience(int EmployeeId,PreviousExprience previousExprience);
        Task<PreviousExprience> UpdatePreviouesExprience(PreviousExprience previousExprience);
        Task DeletePreviouesExprience(PreviousExprience previousExprience);
    }
}
