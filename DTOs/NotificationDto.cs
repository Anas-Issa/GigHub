using GigHub.Models;
using System;

namespace GigHub.DTOs
{
    public class NotificationDto
    {

        public NotificationType Type { get;  set; }
        public DateTime Date { get;  set; } 
        public DateTime? OriginalDate { get; set; }
        public string OriginalVenu { get; set; }
        public GigDto Gig { get;  set; }
    }
}