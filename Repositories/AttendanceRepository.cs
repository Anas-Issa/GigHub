using GigHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendence> GetFutureAttendances(string userid)
        {
            return _context.Attendencies
              .Where(a => a.AttendeeId == userid)
              .ToList();
        }
    }
}