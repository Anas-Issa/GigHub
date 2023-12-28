using GigHub.Models;
using GigHub.Repositories;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        private AttendanceRepository AttendancesRepository;

        public HomeController()
        {
            _context = new ApplicationDbContext();
            AttendancesRepository = new AttendanceRepository(_context);
        }
        public ActionResult Index(string query=null)
        {
            
            var upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled)
                .ToList();

            if (!String.IsNullOrWhiteSpace(query))
            {
                query = query.ToLower();
                upcomingGigs = upcomingGigs
                    .Where(g => g.Artist.Name.ToLower().Contains(query)
                    || g.Genre.Name.ToLower().Contains(query)
                    || g.Venue.ToLower().Contains(query)

                    ).ToList();

            }
            var userid = User.Identity.GetUserId();
              var attendances = AttendancesRepository.GetFutureAttendances(userid)
                .ToLookup(g=>g.GigId);
            var homeVm = new HomeViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm=query,
               Attendances=attendances
            };
            return View("Gigs",homeVm);
        }

        public ActionResult Details(int id)
        {
            var userid = User.Identity.GetUserId();
            var gig = _context.Gigs
                .Include(g => g.Artist)
                //.Include(g=>g.Attendences)
                //.Include(g=>g.Artist.Followees)
                .Single(g => g.Id == id);
            if (gig == null)
                return HttpNotFound();
            var viewmodel = new GigDetailViewModel();
            if (User.Identity.IsAuthenticated)
            {


                viewmodel.ArtistName = gig.Artist.Name;
                viewmodel.Venue = gig.Venue;
                viewmodel.Date = gig.DateTime;
                viewmodel.IsAttendee = _context.Attendencies.Any(a => a.AttendeeId == userid && a.GigId == gig.Id);
                viewmodel.IsFollow = _context.Followings.Any(f => f.FollowerId == userid && f.FolloweeId == gig.ArtistId);

                viewmodel.ArtistId = gig.Artist.Id;   
            }
            
            return View("GigDetails",viewmodel);
        }
        [HttpPost]
        public ActionResult Search(HomeViewModel vm)
        
        {
            return RedirectToAction("Index", "Home", new { query = vm.SearchTerm });
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}