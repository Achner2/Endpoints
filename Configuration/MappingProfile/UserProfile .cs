using API.Dto.Request;
using API.Dto.Response;
using AutoMapper;

namespace API.Configuration.MappingProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Configurar el mapeo de UserRequest a UserResponse
            CreateMap<UserRequest, UserResponse>();
        }
    }
}
