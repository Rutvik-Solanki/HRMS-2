using AutoMapper;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;
using HRMPortal.Employee.Processor.Interface;

namespace HRMPortal.Employee.Processor.Class
{
    public class EmployeeProcessor : IEmployeeProcessor
    {
        private readonly IEmployeeEngine _employeeEngine;
        private readonly IMapper _mapper;

        public EmployeeProcessor(IEmployeeEngine employeeEngine,IMapper mapper)
        {
            _employeeEngine = employeeEngine ?? throw new ArgumentNullException(nameof(employeeEngine));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            return _mapper.Map<IEnumerable<EmployeeDto>>(await _employeeEngine.GetAllEmployees());
        }
        public async Task<EmployeeDetail> GetEmployeeById(int emplyeeId)
        {
            return await _employeeEngine.GetEmployeeById(emplyeeId);
        }
        public async Task<EmployeeDto> AddEmployee(EmployeeAddDto employeeDetails)
        {
           return _mapper.Map<EmployeeDto>(await _employeeEngine.AddEmployee(_mapper.Map<EmployeeDetail>(employeeDetails)));
        }
        public async Task<EmployeeDetail> UpdateEmployee(EmployeeUpdateDto employeeDetailsUpdateDto, int employeeId)
        {
            return await _employeeEngine.UpdateEmployee(employeeDetailsUpdateDto, employeeId);
        }
        public async Task<bool> DeleteEmployee( int employeeId)
        {
            if(await _employeeEngine.DeleteEmployee(employeeId)) return true;
            return false;
        }
    }
}
