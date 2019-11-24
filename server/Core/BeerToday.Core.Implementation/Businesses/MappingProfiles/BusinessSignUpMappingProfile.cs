namespace BeerToday.Core.Implementation.Businesses.MappingProfiles
{
    using AutoMapper;

    using Data.Model.Entities;
    using UserTypeEnum = Data.Model.Enums.UserType;

    using Contracts.Businesses.Notifications;

    public class BusinessSignUpMappingProfile : Profile
    {
        public BusinessSignUpMappingProfile()
        {
            CreateMap<BusinessSignUpNotification, User>()
                .ForMember(user => user.UserTypeId, conf => conf.MapFrom(notification => UserTypeEnum.Business));
        }
    }
}
