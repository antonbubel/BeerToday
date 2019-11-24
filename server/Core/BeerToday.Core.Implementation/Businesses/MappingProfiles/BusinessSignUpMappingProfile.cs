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
                .ForMember(user => user.UserName, conf => conf.MapFrom(notification => notification.Email))
                .ForMember(user => user.FirstName, conf => conf.MapFrom(notification => notification.FirstName))
                .ForMember(user => user.LastName, conf => conf.MapFrom(notification => notification.LastName))
                .ForMember(user => user.UserName, conf => conf.MapFrom(notification => notification.Email))
                .ForMember(user => user.UserTypeId, conf => conf.MapFrom(notification => UserTypeEnum.Business));
        }
    }
}
