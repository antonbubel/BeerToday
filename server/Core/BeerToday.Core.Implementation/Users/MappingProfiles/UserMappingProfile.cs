namespace BeerToday.Core.Implementation.Users.MappingProfiles
{
    using AutoMapper;

    using Data.Model.Entities;

    using Contracts.Users.Notifications;

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<SignUpNotification, User>();
        }
    }
}
