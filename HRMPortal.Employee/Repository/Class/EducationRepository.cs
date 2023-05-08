using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Entity;
using Microsoft.EntityFrameworkCore;

namespace HRMPortal.Employee.Repository
{
    public class EducationRepository : IEducationRepository
    {
        private readonly HRMPortalEmployeeContext context;

        public EducationRepository(HRMPortalEmployeeContext context) 
        {
            this.context = context;
        }

        public async Task<EducationDetail> AddEducationDetails(int EmployeeId, EducationDetail educationDetail)
        {
            educationDetail.EmployeeDetail = await context.EmployeeDetail.FirstOrDefaultAsync(e => e.Id == EmployeeId);
            educationDetail.EmployeeDetailId = EmployeeId;
            await context.EducationDetail.AddAsync(educationDetail);
            await context.SaveChangesAsync();
            return educationDetail;
        }

        public async Task DeleteEducationDetails(EducationDetail educationDetail)
        {
            context.EducationDetail.Remove(educationDetail);
            await context.SaveChangesAsync();
        }

        public async Task<EducationDetail> GetEducationDetailById(int EmplyoeeId, int EducationId)
        {
            return await context.EducationDetail.Where(b => b.EmployeeDetailId == EmplyoeeId).FirstOrDefaultAsync(e => e.Id == EducationId);
        }

        public async Task<IEnumerable<EducationDetail>> GetEducationDetails(int EmployeeId)
        {
           return await context.EducationDetail.Where(e => e.EmployeeDetailId == EmployeeId).ToListAsync();
        }

        public async Task<EducationDetail> UpdateEducationDetails(EducationDetail educationDetail)
        {
            context.EducationDetail.Update(educationDetail);
            context.SaveChanges();
            return educationDetail;
        }
    }
}
