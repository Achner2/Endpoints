using API.Dto.Request;
using API.Dto.Response;
using AutoMapper;
using WebApplication2.Models.Entity;

namespace API.Configuration.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
            CreateMap<UserRequest, User>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
        }   
}
