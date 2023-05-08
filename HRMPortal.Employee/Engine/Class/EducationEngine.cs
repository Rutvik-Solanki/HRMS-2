using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Repository;

namespace HRMPortal.Employee.Engine
{
    public class EducationEngine : IEducationEngine
    {

        private readonly IEducationRepository educationRepository;

        public EducationEngine(IEducationRepository educationRepository)
        {

            this.educationRepository = educationRepository;
        }

        public async Task<EducationDetail> AddEducationDetails(int EmplyoeeId, EducationDetail educationDetail)
        {
            return await educationRepository.AddEducationDetails(EmplyoeeId, educationDetail);
        }

        public async Task DeleteEducationDetails(EducationDetail educationDetail)
        {
            await educationRepository.DeleteEducationDetails(educationDetail);
        }

        public async Task<EducationDetail> GetEducationDetailById(int EmplyoeeId, int EducationId)
        {
            var result = await educationRepository.GetEducationDetailById(EmplyoeeId, EducationId);
            return result;
        }

        public async Task<IEnumerable<EducationDetail>> GetEducationDetails(int EmployeeId)
        {
            var result = await educationRepository.GetEducationDetails(EmployeeId);
            return result;
        }

        public async Task<EducationDetail> UpdateEducationDetails(EducationDetail educationDetailId)
        {
            return await educationRepository.UpdateEducationDetails(educationDetailId);
        }
    }
}
