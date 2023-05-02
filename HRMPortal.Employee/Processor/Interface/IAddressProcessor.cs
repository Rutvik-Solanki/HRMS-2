using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model.AddressModel;
using HRMPortal.Employee.Model.SalaryModel;

namespace HRMPortal.Employee.Processor.Interface
{
    public interface IAddressProcessor
    {
        //get
        Task<IEnumerable<Address>> GetAddressAsync();
        Task<Tuple<Address, Address>> GetAddressByIdAsync(int employeeId);
        Task<AddressDto> GetAddressByIdsAsync(int employeeId, int addressId);

        //add
        Task<AddressDto> AddPermanentAddress(int emplyeeId, AddressDto addressDto);
        Task<AddressDto> AddPresentAddress(int emplyeeId, AddressDto addressDto);

        //update
        Task<AddressDto> UpdateAddress(int employeeId, int addressId, AddressDto addressDto);        

        //delete
        Task<bool> DeleteAddressById(int employeeId, int addressId);
        
    }
}
