using AutoMapper;
using splitourbill_backend.Models.DomainModels;
using splitourbill_backend.Models.RequestModels;
using splitourbill_backend.Models.ResponseModels;
using splitourbill_backend.Utils;

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

            CreateMap<Friendship, PendingFriendRequestResponse>();
            CreateMap<NewFriendshipCreationRequest, Friendship>()
                .ForMember(f => f.Status, memberOptions => memberOptions.MapFrom(nfcr => Constants.RelationshipStatuses.Requested));

            CreateMap<Bill, BillResponse>()
                .ForMember(b => b.Initiator, memberOptions => memberOptions.Ignore())
                .ForMember(b => b.BillSharings, memberOptions => memberOptions.Ignore());
            CreateMap<BillSharing, BillSharingResponse>()
                .ForMember(bsr => bsr.Sharer, memberOptions => memberOptions.Ignore());
        }
    }
}