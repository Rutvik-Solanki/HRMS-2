using AutoMapper;
using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HRMPortal.Employee.Repository.Class
{
	public class AddressRepository : IAddressRepository
	{
		private readonly HRMPortalEmployeeContext _context;
		public AddressRepository(HRMPortalEmployeeContext context)
		{
			this._context = context;			
		}
		public async Task<IEnumerable<Address>> GetAddressAsync()
		{
			return await _context.Addresse.ToListAsync();
		}
		public async Task<Tuple<Address, Address>> GetAddressByIdAsync(int employeeId)
		{
			var employee = await _context.EmployeeDetail
								 .Where(e => e.Id == employeeId)
									.Include("PermanentAddress")
										.Include("PresentAddress")
											.FirstOrDefaultAsync();

			var permanentAddress = employee.PermanentAddress;
			var presentAddress = employee.PresentAddress;

			Tuple<Address, Address> result = new
				Tuple<Address, Address>(permanentAddress, presentAddress);

			return result;

		}

		public async Task<Address> GetAddressByIdsAsync(int employeeId, int addressId)
		{
			var employee = await _context.EmployeeDetail
								.Where(e => e.Id == employeeId)
								   .Include("PermanentAddress")
									.Include("PresentAddress")
									 .FirstOrDefaultAsync();

			var permanentAddress = employee.PermanentAddress;
			var presentAddress = employee.PresentAddress;
			if (employee.PermanentAddressId == addressId)
			{
				return permanentAddress;
			}
			return presentAddress;
		}

		public async Task<Address> AddPermanentAddress(int employeeId, Address address)
		{
			var employee = await _context.EmployeeDetail.FirstOrDefaultAsync(e => e.Id == employeeId);


			if (employee != null)
			{
				if (employee.PermanentAddressId == null)
				{
					employee.PermanentAddress = address;
					await _context.SaveChangesAsync();
				}
				else
				{
					throw new Exception($"PermanentAddress already has in {employeeId}");
				}
			}
			return address;
		}

		public async Task<Address> AddPresentAddress(int employeeId, Address address)
		{
			var employee = await _context.EmployeeDetail.FirstOrDefaultAsync(e => e.Id == employeeId);

			if (employee != null)
			{
				if (employee.PresentAddressId == null)
				{
					employee.PresentAddress = address;
					await _context.SaveChangesAsync();
				}
				else
				{
					throw new Exception($"PresentAddress already has in {employeeId}");
				}
			}
			return address;
		}
		public async Task<Address> UpdateAddress(Address address)
		{
			_context.Addresse.Update(address);
			await _context.SaveChangesAsync();
			return address;
		}

		public void DeleteAddressById(Address address)
		{
			_context.Addresse.Remove(address);
			_context.SaveChanges();
		}
	}
}
