using AutoMapper;

namespace RealEstateProject
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PublicPropertyDto>();
            CreateMap<CreateUpdatePropertyDto, Property>();
            CreateMap<Property, PropertyListDto>();

        }
    }
}
