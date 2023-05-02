using AutoMapper;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model.PreviousExprience;
using HRMPortal.Employee.Processor;
using HRMPortal.Employee.Processor.Interface;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Controller
{
    [ApiController]
    [Route("api/employee/{EmployeeId}/previousexprience/")]
    public class PreviousExprienceController : ControllerBase
    {
        private readonly IPreviousExprienceProcessor _previousExprienceProcessor;
        private readonly IMapper _mapper;

        public PreviousExprienceController(
            IPreviousExprienceProcessor previousExprienceProcessor,
            IMapper mapper
            )
        {
            _previousExprienceProcessor = previousExprienceProcessor;
            _mapper = mapper;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetPreviouesExprienceByEmployeeId([FromRoute] int EmployeeId)
        {
            return Ok(await _previousExprienceProcessor.GetPreviouesExprienceByEmployeeId(EmployeeId));
        }

        [HttpGet("{PreviousExprienceId}")]
        public async Task<IActionResult> GetPreviouesExprienceById([FromRoute] int EmployeeId, [FromRoute] int PreviousExprienceId)
        {
            return Ok(await _previousExprienceProcessor.GetPreviouesExprienceById(EmployeeId, PreviousExprienceId));
        }

        [HttpPost]
        public async Task<IActionResult> AddpreviousExprience([FromRoute] int EmployeeId, PreviousExprienceAddDto previousExprience)
        {
            return Ok(await _previousExprienceProcessor.AddPreviouesExprience(EmployeeId, previousExprience));
        }

        [HttpPut("{PreviousExprienceId}")]
        public async Task<IActionResult> UpdatePreviouesExprience([FromRoute] int EmployeeId, [FromRoute] int PreviousExprienceId,  PreviousExprienceUpdateDto previousExprienceUpdateDto)
        {
            
            await _previousExprienceProcessor.UpdatePreviouesExprience(EmployeeId, PreviousExprienceId, previousExprienceUpdateDto);
            return Ok();
        }

        /* [HttpPatch("{PreviousExprienceId}")]
         public async Task<IActionResult> PatchPreviouesExprience([FromRoute] int EmployeeId, [FromRoute] int PreviousExprienceId, JsonPatchDocument<PreviousExprienceGetDto> previousExprienceDto)
         {
             var previousExprience = await _previousExprienceProcessor.GetPreviouesExprienceById(EmployeeId, PreviousExprienceId);
             var result = _mapper.Map<PreviousExprienceGetDto>(previousExprience);
             previousExprienceDto.ApplyTo(result, ModelState);
             await _previousExprienceProcessor.UpdatePreviouesExprience(EmployeeId, _mapper.Map(previousExprienceDto, previousExprience));
             return Ok();

         }*/

        [HttpDelete("{PreviousExprienceId}")]
        public async Task<IActionResult> DeletePreviouesExprience([FromRoute] int EmployeeId, [FromRoute] int PreviousExprienceId)
        {
             await _previousExprienceProcessor.DeletePreviouesExprience(EmployeeId, PreviousExprienceId);
            return Ok();
        }


    }
}
