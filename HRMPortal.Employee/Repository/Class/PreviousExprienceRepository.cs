using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Engine;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model;
using HRMPortal.Employee.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMPortal.Employee.Repository.Class
{
    public class PreviousExprienceRepository : IPreviousExprienceRepository
    {
        private readonly HRMPortalEmployeeContext _context;

        /// <summary>
        /// Database Layer
        /// </summary>
        /// <param name="context"></param>
        public PreviousExprienceRepository(HRMPortalEmployeeContext context)
        {
            _context = context;
        }

        public async Task<PreviousExprience> AddPreviouesExprience(int EmployeeId, PreviousExprience previousExprience)
        {
           previousExprience.EmployeeDetail= await _context.EmployeeDetail.FirstOrDefaultAsync(e=> e.Id == EmployeeId);
            previousExprience.EmployeeDetailId = EmployeeId;
            await _context.PreviousExprience.AddAsync(previousExprience);
            await _context.SaveChangesAsync();
            return previousExprience;
        }
      
        public async Task DeletePreviouesExprience(PreviousExprience previousExprience)
        {
             _context.PreviousExprience.Remove(previousExprience);
              await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<PreviousExprience>> GetPreviouesExprienceByEmployeeId(int EmployeeId)
        {
            return await _context.PreviousExprience.Where(e => e.EmployeeDetailId == EmployeeId).ToListAsync();
        }

        public async Task<PreviousExprience> GetPreviouesExprienceById(int EmployeeId, int PreviousExprienceId)
        {
            return await _context.PreviousExprience.Where(e => e.EmployeeDetailId == EmployeeId).FirstOrDefaultAsync(p=> p.Id == PreviousExprienceId);
            
        }

        public async Task<PreviousExprience> UpdatePreviouesExprience(PreviousExprience previousExprience)
        {
            _context.PreviousExprience.Update(previousExprience);
            await _context.SaveChangesAsync();
            return previousExprience;
        }

        /*  public void Save(PreviousExprience previousExprience)
          {
              _context.ChangeTracker.TrackGraph(previousExprience, p => { 
                  p.Entry.Property("CreateAt").IsModified = false;
                  p.Entry.Property("CreateBy").IsModified = false;
              });
              //_context.Entry(previousExprience).Property("CreateAt").IsModified = false;
              _context.SaveChanges();
          }*/


    }
}
