using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Engine.Interface
{
    public interface IAddressEngine
    {
        //get
        Task<IEnumerable<Address>> GetAddressAsync();
        Task<Tuple<Address, Address>> GetAddressByIdAsync(int employeeId);
        Task<Address> GetAddressByIdsAsync(int employeeId, int addressId);

        //add
        Task<Address> AddPermanentAddress(int emplyeeId, Address address);
        Task<Address> AddPresentAddress(int emplyeeId, Address address);

        //update
        Task<Address> UpdateAddress(Address address);

        //delete
        void DeleteAddressById(Address address);

    }
}
