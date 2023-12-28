using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userid = User.Identity.GetUserId();
            var gig = _context.Gigs
                .Include(g=>g.Attendences.Select(a=>a.Attendee))
                .Single(g => g.ArtistId == userid && g.Id == id);
            if (gig.IsCanceled)
                return NotFound();
            gig.Cancel();
            _context.SaveChanges();
            return Ok();
        }

        

    }
}
