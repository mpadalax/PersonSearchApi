using AutoMapper;
using PersonSearchApi.Data.Dtos;
using PersonSearchApi.Data.Models;

namespace PersonSearchApi.Data.Mappers 
{ 
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      CreateMap<Person, PersonDto>();
      CreateMap<Address, AddressDto>();
      CreateMap<Interest, InterestDto>();
    }
  }
}
