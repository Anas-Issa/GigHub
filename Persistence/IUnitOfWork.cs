using GigHub.Repositories;

namespace GigHub.Persistence
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendance { get; }
        IGenreRepository Genre { get; }
        IGigRepository Gig { get; }
        IFollowingRepository Following { get; }

        void Complete();
    }
}