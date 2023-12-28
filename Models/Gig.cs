using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Models
{
    public class Gig
    {
        
        public int Id { get; set; }

        public bool IsCanceled { get;private set; }
        public ApplicationUser Artist { get; set; }
        [Required]
        public string  ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        
        public Genre Genre { get; set; }
        [Required]  
        public int GenreId { get; set; }
        public ICollection<Attendence> Attendences { get; internal set; }
        public Gig()
        {
            Attendences = new Collection<Attendence>();
        }
        internal void Cancel()
        {
            IsCanceled = true;
            var notification = Notification.gigCanceled(this);

            //var atendees = _context.Attendencies
            //    .Where(a => a.GigId == gig.Id)
            //    .Select(a => a.Attendee)
            //    .ToList();
            foreach (var atendee in Attendences.Select(a => a.Attendee))
            {
                atendee.Notify(notification);
            }

        }

        internal void Modify(DateTime datetime, string venue, int genreId)
        {

            var notification =  Notification.GigUpdated( this, DateTime,Venue);
          

            Venue = venue;
            DateTime = datetime;
            GenreId = GenreId;
            foreach(var attendee in Attendences.Select(a=>a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}