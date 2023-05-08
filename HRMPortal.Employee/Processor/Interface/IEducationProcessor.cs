using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Processor
{
    public interface IEducationProcessor
    {
        Task<IEnumerable<EducationDetailDto>> GetEducationDetails(int EmplyoeeId);
        Task<EducationDetailDto> GetEducationDetailById(int EmplyoeeId, int EducationId);
        Task<EducationDetailDto> AddEducationDetails(int EmplyoeeId, EducationDetail educationDetail);
        Task<EducationDetailDto> UpdateEducationDetails(int EmplyoeeId, int educationDetailId,EducationDetailDto educationDetailDto);

        // update
        //Task Update(BankDetail bankDetail);

        Task DeleteEducationDetails(int EmplyoeeId, int EducationId);
    }
}
