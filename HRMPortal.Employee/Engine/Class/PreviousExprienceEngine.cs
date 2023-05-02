using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model;
using HRMPortal.Employee.Processor;
using HRMPortal.Employee.Repository.Interface;

namespace HRMPortal.Employee.Engine.Class
{
    public class PreviousExprienceEngine : IPreviousExprienceEngine
    {
        private readonly IPreviousExprienceRepository _previousExprienceRepository;

        /// <summary>
        /// Busiess Layer
        /// </summary>
        /// <param name="repository"></param>
        public PreviousExprienceEngine(IPreviousExprienceRepository previousExprienceRepository)
        {
            _previousExprienceRepository = previousExprienceRepository;
        }

        public async Task<PreviousExprience> AddPreviouesExprience(int EmployeeId, PreviousExprience previousExprience)
        {
           if(previousExprience != null) 
           {
               return await _previousExprienceRepository.AddPreviouesExprience(EmployeeId, previousExprience);
           }
            else
            {
                throw new Exception("Data Can't Added");
            }

            
            
        }

        public async Task DeletePreviouesExprience(PreviousExprience previousExprience)
        {
            if(previousExprience != null)
            {
                await _previousExprienceRepository.DeletePreviouesExprience(previousExprience);
            }
            else
            {
                throw new Exception("Data Can't Deleted");
            }
           
        }


        public async Task<IEnumerable<PreviousExprience>> GetPreviouesExprienceByEmployeeId(int EmployeeId)
        {
            var result = await _previousExprienceRepository.GetPreviouesExprienceByEmployeeId(EmployeeId);
            if(result.Count() <= 0)
            {
                throw new Exception($"EmployeeId {EmployeeId} Was Not Found");
            }
            else
            {
                return result;
            }
        }

        public async Task<PreviousExprience> GetPreviouesExprienceById(int EmployeeId, int PreviousExprienceId)
        {
            var result = await _previousExprienceRepository.GetPreviouesExprienceById(EmployeeId,PreviousExprienceId);
            if (result == null)
            {
                throw new Exception($"PreviousExprience {PreviousExprienceId} Was Not Found");
            }
            else
            {
                return result;
            }
        }

        public async Task<PreviousExprience> UpdatePreviouesExprience(PreviousExprience previousExprience)
        {
            if(previousExprience != null)
            {
                return await _previousExprienceRepository.UpdatePreviouesExprience(previousExprience);
            }
            else
            {
                throw new Exception("Data Can't be Updated");
            }
            
          
        }
    }
}
