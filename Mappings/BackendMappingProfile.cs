using AutoMapper;
using splitourbill_backend.Models.DomainModels;
using splitourbill_backend.Models.RequestModels;
using splitourbill_backend.Models.ResponseModels;

namespace splitourbill_backend.Mappings
{
    public class BackendMappingProfile : Profile
    {
        public BackendMappingProfile()
        {
            CreateMap<NewUserCreationRequest, User>();
            CreateMap<UpdateUserInfoRequest, User>();

            CreateMap<User, UserSimpleResponse>();
            CreateMap<User, UserFullResponse>();
        }
    }
}