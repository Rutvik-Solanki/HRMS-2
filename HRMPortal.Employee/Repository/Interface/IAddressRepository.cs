using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Repository.Interface
{
    public interface IAddressRepository
    {
        //get
        Task<IEnumerable<Address>> GetAddressAsync();
        Task<Tuple<Address, Address>> GetAddressByIdAsync(int employeeId);
        Task<Address> GetAddressByIdsAsync(int employeeId, int addressId);

        //add
        Task<Address> AddPermanentAddress(int employeeId, Address address);
        Task<Address> AddPresentAddress(int employeeId, Address address);

        //update
        Task<Address> UpdateAddress(Address address);

        //delete
        void DeleteAddressById(Address address);

    }
}
