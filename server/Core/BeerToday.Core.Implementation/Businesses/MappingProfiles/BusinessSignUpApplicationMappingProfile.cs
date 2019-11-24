namespace BeerToday.Core.Implementation.Businesses.MappingProfiles
{
    using AutoMapper;

    using Data.Model.Entities;
    using BusinessSignUpApplicationStatusEnum = Data.Model.Enums.BusinessSignUpApplicationStatus;

    using Contracts.Businesses.Notifications;

    public class BusinessSignUpApplicationMappingProfile : Profile
    {
        public BusinessSignUpApplicationMappingProfile()
        {
            CreateMap<CreateBusinessSignUpApplicationNotification, BusinessSignUpApplication>()
                .ForMember(application => application.FirstName, conf => conf.MapFrom(notification => notification.FirstName))
                .ForMember(application => application.LastName, conf => conf.MapFrom(notification => notification.LastName))
                .ForMember(application => application.Email, conf => conf.MapFrom(notification => notification.Email))
                .ForMember(application => application.PhoneNumber, conf => conf.MapFrom(notification => notification.PhoneNumber))
                .ForMember(application => application.OrganizationName, conf => conf.MapFrom(notification => notification.OrganizationName))
                .ForMember(application => application.OrganizationAddress, conf => conf.MapFrom(notification => notification.OrganizationAddress))
                .ForMember(application => application.Website, conf => conf.MapFrom(notification => notification.Website))
                .ForMember(application => application.Comment, conf => conf.MapFrom(notification => notification.Comment))
                .ForMember(application => application.CountryId, conf => conf.MapFrom(notification => notification.Country))
                .ForMember(application => application.Country, conf => conf.Ignore())
                .ForMember(application => application.StatusId, conf => conf.MapFrom(notification => BusinessSignUpApplicationStatusEnum.Undefined))
                .ForMember(application => application.Status, conf => conf.Ignore());
        }
    }
}
