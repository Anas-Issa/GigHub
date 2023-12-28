using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public NotificationType Type { get;private set; }
        public DateTime Date { get;private set; }
        public DateTime? OriginalDate { get; set; }
        public string OriginalVenu { get; set; }
        [Required]
        public Gig Gig { get;private set; }

        protected Notification()
        {

        }
        private Notification(NotificationType type,Gig gig)
        {
            if (gig == null)
                throw new ArgumentNullException("gig");

            Type = type;
            Gig = gig;
            Date = DateTime.Now;


        }
        public static Notification gigCreated(Gig gig)
        {
            return new Notification(NotificationType.GigCreated, gig);
        } 
        public static Notification gigCanceled(Gig gig)
        {
            return new Notification(NotificationType.GigCanceled, gig);
        }
        public static Notification GigUpdated (Gig newGig,DateTime originaldate,string originalvenu)
        {
            var notification = new Notification(NotificationType.GigUpdated, newGig);

            notification.OriginalDate = originaldate;
            notification.OriginalVenu = originalvenu;
            
            return  notification;
        }
    }
}