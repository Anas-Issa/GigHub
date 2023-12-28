using GigHub.DTOs;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult Follow (FollowDto dto)
        {
            var userid = User.Identity.GetUserId();
            var exist = _context.Followings.Any(f => f.FolloweeId == userid && f.FolloweeId == dto.FolloweeId);
            if (exist)
                return BadRequest("Already Following this Artist");
                    var follow = new following
                    {
                        FollowerId = userid,
                        FolloweeId = dto.FolloweeId
                    };
            _context.Followings.Add(follow);
            _context.SaveChanges();
            return Ok();
            
        }

        [HttpPost]
        public IHttpActionResult CreateFollow(string artistid)
        {
            var userid = User.Identity.GetUserId();
            var exist = _context.Followings.Any(f => f.FollowerId == userid && f.FolloweeId == artistid);
            if (exist)
                return BadRequest("Already Following this Artist");
            var follow = new following
            {
                FollowerId = userid,
                FolloweeId = artistid
            };
            _context.Followings.Add(follow);
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var userid = User.Identity.GetUserId();
            var follow = _context.Followings.Single(f => f.FollowerId == userid && f.FolloweeId == id);

            _context.Followings.Remove(follow);
            _context.SaveChanges();
            return Ok();
        }

    }
}
