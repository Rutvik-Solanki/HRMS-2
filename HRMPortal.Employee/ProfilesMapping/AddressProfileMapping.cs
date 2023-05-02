using AutoMapper;

namespace HRMPortal.Employee.ProfilesMapping
{
    public class AddressProfileMapping : Profile
    {
        public AddressProfileMapping()
        {
            CreateMap<Model.AddressModel.AddressDto, Entity.Address>();
        }
    }
}
