using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Repository.Class;
using HRMPortal.Employee.Repository.Interface;

namespace HRMPortal.Employee.Engine.Class
{
    public class AddressEngine : IAddressEngine
    {
        private readonly IAddressRepository _addressRepository;

        public AddressEngine(IAddressRepository addressRepository)
        {
            this._addressRepository = addressRepository;
        }
        public async Task<Address> AddPermanentAddress(int emplyeeId, Address address)
        {
            return await _addressRepository.AddPermanentAddress(emplyeeId, address);
        }

        public async Task<Address> AddPresentAddress(int emplyeeId, Address address)
        {
            return await _addressRepository.AddPresentAddress(emplyeeId, address);
        }


        public async Task<IEnumerable<Address>> GetAddressAsync()
        {
          return await _addressRepository.GetAddressAsync();
        }

        public async Task<Tuple<Address, Address>> GetAddressByIdAsync(int employeeId)
        {
            return await _addressRepository.GetAddressByIdAsync(employeeId);
        }

        public async Task<Address> GetAddressByIdsAsync(int employeeId, int addressId)
        {
            return await _addressRepository.GetAddressByIdsAsync(employeeId ,addressId);
        }

        public async Task<Address> UpdateAddress(Address address)
        {
           return await _addressRepository.UpdateAddress(address);
        }
        public void DeleteAddressById(Address address)
        {
            _addressRepository.DeleteAddressById(address);
        }
    }
}
