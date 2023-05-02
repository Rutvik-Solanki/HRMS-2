using AutoMapper;
using HRMPortal.Employee.Engine.Class;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model.AddressModel;
using HRMPortal.Employee.Model.SalaryModel;
using HRMPortal.Employee.Processor.Interface;

namespace HRMPortal.Employee.Processor.Class
{
    public class AddressProcessor : IAddressProcessor
    {
        private readonly IAddressEngine _addressEngine;
        private readonly IMapper _mapper;

        public AddressProcessor(IAddressEngine addressEngine, IMapper mapper)
        {
            this._addressEngine = addressEngine;
            this._mapper = mapper;
        }
        public async Task<AddressDto> AddPermanentAddress(int emplyeeId, AddressDto addressDto)
        {
            return _mapper.Map<AddressDto>(await _addressEngine.AddPermanentAddress(emplyeeId, _mapper.Map<Address>(addressDto)));
        }

        public async Task<AddressDto> AddPresentAddress(int emplyeeId, AddressDto addressDto)
        {
            return _mapper.Map<AddressDto>(await _addressEngine.AddPresentAddress(emplyeeId, _mapper.Map<Address>(addressDto)));
        }


        public async Task<IEnumerable<Address>> GetAddressAsync()
        {
            return await _addressEngine.GetAddressAsync();
        }

        public async Task<Tuple<Address, Address>> GetAddressByIdAsync(int employeeId)
        {
            return await _addressEngine.GetAddressByIdAsync(employeeId);
        }

        public async Task<AddressDto> GetAddressByIdsAsync(int employeeId, int addressId)
        {
            return _mapper.Map<AddressDto>(await _addressEngine.GetAddressByIdsAsync(employeeId,addressId));
        }

        
        public async Task<AddressDto> UpdateAddress(int employeeId, int addressId, AddressDto addressDto)
        {
            var getId = await _addressEngine.GetAddressByIdsAsync(employeeId, addressId);
            if(getId != null)
            {
                return _mapper.Map<AddressDto>(await _addressEngine.UpdateAddress(_mapper.Map(addressDto, getId)));
            }
            return null;
        }
       
        public async Task<bool> DeleteAddressById(int employeeId, int addressId)
        {
            var getId = await _addressEngine.GetAddressByIdsAsync(employeeId, addressId);
            if (getId != null)
            {
                _addressEngine.DeleteAddressById(_mapper.Map<Address>(getId));
                return true;
            }
            return false;

        }

    }
}
