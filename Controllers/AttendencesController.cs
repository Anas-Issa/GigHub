using GigHub.DTOs;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendencesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userid = User.Identity.GetUserId();
            var attendance = _context.Attendencies.Single(a => a.AttendeeId == userid && a.GigId == id);
            if (attendance == null)
                return NotFound();
            _context.Attendencies.Remove(attendance);
            _context.SaveChanges();
            return Ok();

        }
        [HttpPost]
        public IHttpActionResult Attenddence (AttendenceDto dto)
        {

            var userId = User.Identity.GetUserId();
           var exist= _context.Attendencies.Any(a => a.AttendeeId == userId && a.GigId ==dto.gigid);
            if (exist)
                return BadRequest("This Attendence is already exist");
            var attendence = new Attendence
            {
                GigId = dto.gigid,
                AttendeeId=userId,
            };
            _context.Attendencies.Add(attendence);
            _context.SaveChanges();
            return Ok();
        }
    }
}
