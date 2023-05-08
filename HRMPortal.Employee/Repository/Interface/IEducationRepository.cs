using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Repository
{
    public interface IEducationRepository
    {

        Task<IEnumerable<EducationDetail>> GetEducationDetails(int EducationId);
        Task<EducationDetail> GetEducationDetailById(int EmplyoeeId, int EducationId);
        Task<EducationDetail> AddEducationDetails(int EmplyoeeId, EducationDetail educationDetail);
        Task<EducationDetail> UpdateEducationDetails(EducationDetail educationDetail);

        // update
        //Task Update(BankDetail bankDetail);

        Task DeleteEducationDetails(EducationDetail educationDetail);
    }
}
