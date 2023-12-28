using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GigHub.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {

        private readonly ApplicationDbContext _context;
        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ApplicationUser> GetFollowings(string userid)
        {
            return _context.Followings.Where(f => f.FollowerId == userid).Include(f => f.Followee).Select(f => f.Followee).ToList();
        }
    }
}