using AutoMapper;
using HRMPortal.Employee.Engine;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Processor
{
    public class EducationProcessor : IEducationProcessor
    {
        private readonly IEducationEngine educationEngine;
        private readonly IMapper mapper;

        public EducationProcessor(IEducationEngine educationEngine, IMapper mapper) 
        {
            this.educationEngine = educationEngine;
            this.mapper = mapper;
        }

        public async Task<EducationDetailDto> AddEducationDetails(int EmplyoeeId, EducationDetail educationDetail)
        {
            return mapper.Map<EducationDetailDto>(await educationEngine.AddEducationDetails(EmplyoeeId, mapper.Map<EducationDetail>(educationDetail)));
        }

        public async Task DeleteEducationDetails(int EmplyoeeId, int EducationId)
        {
            var x = await educationEngine.GetEducationDetailById(EmplyoeeId, EducationId);
            await educationEngine.DeleteEducationDetails(mapper.Map<EducationDetail>(x));
        }

        public async Task<EducationDetailDto> GetEducationDetailById(int EmplyoeeId, int EducationId)
        {
            return mapper.Map<EducationDetailDto>(await educationEngine.GetEducationDetailById(EmplyoeeId, EducationId));
        }

        public async Task<IEnumerable<EducationDetailDto>> GetEducationDetails(int EmplyoeeId)
        {
            return mapper.Map<IEnumerable<EducationDetailDto>>(await educationEngine.GetEducationDetails(EmplyoeeId));
        }

        public async Task<EducationDetailDto> UpdateEducationDetails(int EmplyoeeId, int educationDetailId, EducationDetailDto educationDetailDto)
        {
            var x = await educationEngine.GetEducationDetailById(EmplyoeeId, educationDetailId);
            if (x != null)
            {
                return mapper.Map<EducationDetailDto>(await educationEngine.UpdateEducationDetails(mapper.Map(educationDetailDto, x)));
            }
            return null;
        }
    }
}

       
