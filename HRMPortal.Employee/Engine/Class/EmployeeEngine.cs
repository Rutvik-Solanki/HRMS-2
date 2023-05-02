using AutoMapper;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;
using HRMPortal.Employee.Repository.Interface;

namespace HRMPortal.Employee.Engine.Class
{
    public class EmployeeEngine : IEmployeeEngine
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeEngine(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<EmployeeDetail>> GetAllEmployees()
        {
           return await _employeeRepository.GetAllEmployees();
        }
        public async Task<EmployeeDetail> GetEmployeeById(int emplyeeId)
        {
            return await _employeeRepository.GetEmployeeById(emplyeeId);
        }
        public Task<EmployeeDetail> AddEmployee(EmployeeDetail employeeDetail)
        {
            return _employeeRepository.AddEmployee(employeeDetail);
        }
        public async Task<EmployeeDetail> UpdateEmployee(EmployeeUpdateDto employeeDetailsUpdateDto,int employeeId)
        {
            var existEmployee=await _employeeRepository.GetEmployeeById(employeeId);
            if(existEmployee != null)
            {
                return await _employeeRepository.UpdateEmployee(_mapper.Map(employeeDetailsUpdateDto,existEmployee));
            }
            return null;
        }
        public async Task<bool> DeleteEmployee(int employeeId)
        {
            var existEmployee = await _employeeRepository.GetEmployeeById(employeeId);
            if (existEmployee != null)
            {
               if(await _employeeRepository.DeleteEmployee(existEmployee))
                {
                    return true;
                }
               return false;
            }
            return false;
            
        }
    }
}
