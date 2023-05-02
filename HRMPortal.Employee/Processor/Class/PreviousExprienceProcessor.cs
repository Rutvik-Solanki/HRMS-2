using AutoMapper;
using HRMPortal.Employee.Engine;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model.PreviousExprience;
using HRMPortal.Employee.Processor.Interface;

namespace HRMPortal.Employee.Processor.Class
{
    public class PreviousExprienceProcessor : IPreviousExprienceProcessor
    {
        private readonly IPreviousExprienceEngine _previousExprienceEngine;
        private readonly IMapper _mapper;

        /// <summary>
        /// ????
        /// </summary>
        /// <param name="engine"></param>
        public PreviousExprienceProcessor(
            IPreviousExprienceEngine previousExprienceEngine,
            IMapper mapper)
        {
            _previousExprienceEngine = previousExprienceEngine;
            _mapper = mapper;
        }

        public async Task<PreviousExprienceAddDto> AddPreviouesExprience(int EmployeeId, PreviousExprienceAddDto previousExprience)
        {
             return _mapper.Map<PreviousExprienceAddDto>(await _previousExprienceEngine.AddPreviouesExprience(EmployeeId, _mapper.Map<PreviousExprience>(previousExprience)));
            
        } 

        public async Task DeletePreviouesExprience(int EmployeeId, int PreviousExprienceId)
        {
            var result = await _previousExprienceEngine.GetPreviouesExprienceById(EmployeeId, PreviousExprienceId);
            await _previousExprienceEngine.DeletePreviouesExprience(_mapper.Map<PreviousExprience>(result));
        }

        public async Task<IEnumerable<PreviousExprienceGetDto>> GetPreviouesExprienceByEmployeeId(int EmployeeId)
        {
           
            return _mapper.Map<IEnumerable<PreviousExprienceGetDto>>(await _previousExprienceEngine.GetPreviouesExprienceByEmployeeId(EmployeeId));
            
        }

        public async Task<PreviousExprienceGetDto> GetPreviouesExprienceById(int EmployeeId, int PreviousExprienceId)
        {
            return _mapper.Map<PreviousExprienceGetDto>(await _previousExprienceEngine.GetPreviouesExprienceById(EmployeeId, PreviousExprienceId));
        }

        public async Task<PreviousExprienceUpdateDto> UpdatePreviouesExprience(int EmployeeId, int PreviousExprienceId, PreviousExprienceUpdateDto previousExprienceUpdateDto)
        {
            var previousExprience = await _previousExprienceEngine.GetPreviouesExprienceById(EmployeeId, PreviousExprienceId);
            return _mapper.Map<PreviousExprienceUpdateDto>(await _previousExprienceEngine.UpdatePreviouesExprience(_mapper.Map(previousExprienceUpdateDto, previousExprience)));

            //return _mapper.Map<PreviousExprienceUpdateDto>(await _previousExprienceEngine.UpdatePreviouesExprience(EmployeeId, _mapper.Map<PreviousExprience>(previousExprienceUpdateDto)));
            
        }
    }
}
