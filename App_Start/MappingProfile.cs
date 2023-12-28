using AutoMapper;
using GigHub.DTOs;
using GigHub.Models;

namespace GigHub.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}