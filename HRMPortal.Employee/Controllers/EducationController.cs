using AutoMapper;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;
using HRMPortal.Employee.Processor;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Controller
{
    [ApiController]
    [Route("api/emplyoee/{emplyoeeId}/educationDetail")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationProcessor educationProcessor;
        private readonly IMapper mapper;

        public EducationController(IEducationProcessor educationProcessor , IMapper mapper) 
        {
            this.educationProcessor = educationProcessor;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EducationDetailDto>> GetEducationDetail(int emplyoeeId)
        {
            var x = await educationProcessor.GetEducationDetails(emplyoeeId);
            return Ok(x);
        }

        [HttpGet("{EducationDetailId}")]
        public async Task<IActionResult> GetEducationDetailId(int emplyoeeId, int EducationDetailId)
        {
            var x = await educationProcessor.GetEducationDetailById(emplyoeeId, EducationDetailId);
            return Ok(x);
        }

        [HttpPost]
        public async Task<IActionResult> AddEducationDetails(int emplyoeeId, EducationDetailDto educationDetailDto)
        {
            await educationProcessor.AddEducationDetails(emplyoeeId, mapper.Map<EducationDetail>(educationDetailDto));
            return Ok();

        }

        [HttpPut("{EducationDetailId}")]
        public async Task<IActionResult> UpdateEducationDetails(int emplyoeeId, int EducationDetailId, EducationDetailDto educationDetailDto)
        {

            await educationProcessor.UpdateEducationDetails(emplyoeeId, EducationDetailId, educationDetailDto);
            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBankDetail(int emplyoeeId, int EducationId)
        {

            await educationProcessor.DeleteEducationDetails(emplyoeeId, EducationId);
            return Ok();
        }
    }
}
