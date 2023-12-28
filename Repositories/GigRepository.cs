using GigHub.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;
        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Gig> GetUserGigs(string userid)
        {
            return _context.Attendencies
                .Where(a => a.AttendeeId == userid)

                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)

                .ToList();
        }
        public IEnumerable<Gig> GetGigWithArtist()
        {
            return _context.Gigs.Include(g => g.Genre).ToList();
        }

        public Gig GetGigsWithAttendees(int gigid)
        {
            return _context.Gigs
                   .Include(g => g.Attendences.Select(a => a.Attendee))
                   .Single(g => g.Id == gigid);

        }

        public Gig GetGig(int id)
        {
            return _context.Gigs.Single(g => g.Id == id);
        }
        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }
    }

}