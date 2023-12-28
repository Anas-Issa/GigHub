using GigHub.Models;
using GigHub.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGigRepository Gig { get; private set; }
        public IGenreRepository Genre { get; private set; }
        public IAttendanceRepository Attendance { get; private set; }
        public IFollowingRepository Following { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gig = new GigRepository(context);
            Genre = new GenreRepository(context);
            Attendance = new AttendanceRepository(context);
            Following = new FollowingRepository(context);

        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}