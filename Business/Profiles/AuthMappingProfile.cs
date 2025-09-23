using AutoMapper;
using Business.Dtos.Request.Auth;
using Core.Entities.Concrete;


namespace Business.Profiles
{
    public class AuthMappingProfile:Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<CreateRegisterRequest, User>().ReverseMap();
        }
    }
}
