using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IFollowingRepository
    {
        IEnumerable<ApplicationUser> GetFollowings(string userid);
    }
}