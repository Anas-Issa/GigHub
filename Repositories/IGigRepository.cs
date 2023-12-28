using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IGigRepository
    {
        Gig GetGig(int id);
        Gig GetGigsWithAttendees(int gigid);
        IEnumerable<Gig> GetUserGigs(string userid);
        IEnumerable<Gig> GetGigWithArtist();

        void Add(Gig gig);
    }
}