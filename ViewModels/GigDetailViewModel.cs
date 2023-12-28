using System;

namespace GigHub.ViewModels
{
    public class GigDetailViewModel
    {
        public string  ArtistName { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public bool IsAttendee { get; set; }
        public bool IsFollow { get; set; }

        public string ArtistId { get; set; }
    }
}