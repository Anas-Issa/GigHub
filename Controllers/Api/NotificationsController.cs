using AutoMapper;
using GigHub.DTOs;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> GetUserNotification()
        {
            var userid = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(n => n.userid == userid && !n.IsRead)
                .Select(n => n.Notification)
                .Include(n => n.Gig)
                .Include(n=>n.Gig.Artist)
                ;


            var result = notifications.Select(Mapper.Map<Notification, NotificationDto>);
           //     var result=     notifications.Select(n=> new NotificationDto() { 

            //  Date=n.Date,
            //Gig = new GigDto ()
            //{
            //    Artist = new UserDto()
            //    {
            //        Id = n.Gig.ArtistId,
            //        Name = n.Gig.Artist.Name
            //    },
            //    Genre = new GenreDto()
            //    {
            //        Id = n.Gig.GenreId,
            //        Name = n.Gig.Genre.Name
            //    },
            //    DateTime = n.Gig.DateTime,
            //    Venue = n.Gig.Venue,
            //    ID = n.Gig.Id,
            //    IsCanceled = n.Gig.IsCanceled
            //},
            //OriginalDate =n.OriginalDate,
            //  OriginalVenu=n.OriginalVenu,
            //  Type=n.Type

            // }).ToList();
            return result;
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userid = User.Identity.GetUserId();
            var notifications = _context.UserNotifications.Where(n => n.userid == userid && !n.IsRead).ToList();
            notifications.ForEach(n => n.Read());
            _context.SaveChanges();
            return Ok();
        }
    }
}
