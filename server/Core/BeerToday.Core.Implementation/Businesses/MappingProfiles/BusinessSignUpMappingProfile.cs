namespace BeerToday.Core.Implementation.Businesses.MappingProfiles
{
    using AutoMapper;

    using Data.Model.Entities;
    using UserTypeEnum = Data.Model.Enums.UserType;

    public class BusinessSignUpMappingProfile : Profile
    {
        public BusinessSignUpMappingProfile()
        {
            CreateMap<BusinessSignUpInvitation, User>()
                .ForMember(user => user.UserName, conf => conf.MapFrom(invitation => invitation.BusinessSignUpApplication.Email))
                .ForMember(user => user.FirstName, conf => conf.MapFrom(invitation => invitation.BusinessSignUpApplication.FirstName))
                .ForMember(user => user.LastName, conf => conf.MapFrom(invitation => invitation.BusinessSignUpApplication.LastName))
                .ForMember(user => user.Email, conf => conf.MapFrom(invitation => invitation.BusinessSignUpApplication.Email))
                .ForMember(user => user.PhoneNumber, conf => conf.MapFrom(invitation => invitation.BusinessSignUpApplication.PhoneNumber))
                .ForMember(user => user.UserTypeId, conf => conf.MapFrom(invitation => UserTypeEnum.Business));
        }
    }
}
