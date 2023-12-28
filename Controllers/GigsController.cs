using GigHub.Models;
using GigHub.Persistence;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        //private readonly ApplicationDbContext _context;

        //private GigRepository unitOfWork.Gigs;
      
        private readonly IUnitOfWork unitOfWork;

        public GigsController(IUnitOfWork unitofwork)
        {
            //_context = new ApplicationDbContext();
            //unitOfWork.Gigs = new GigRepository();

           // unitOfWork = new UnitOfWork(new ApplicationDbContext());
            unitOfWork = unitofwork;
        }
        // GET: Gigs
        public ActionResult Index()
        {
         
            return View();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = unitOfWork.Genre.GetGenres(),
                Heading="Add a Gig"
            };
            return View("GigForm",viewModel);
        }



        [Authorize]
        public ActionResult Edit(int id)
        {
            var userid = User.Identity.GetUserId();
            var gig=unitOfWork.Gig.GetGig(id);
            if (gig == null)
                return HttpNotFound();
            if (gig.ArtistId != userid)
                return new HttpUnauthorizedResult();

            var viewModel = new GigFormViewModel
            {
                Id=id,
                Genres = unitOfWork.Genre.GetGenres(),
                Venue=gig.Venue,
                Date=gig.DateTime.ToString("dd MMM yyyy"),
                Time=gig.DateTime.ToString("HH:mm"),
                GenreId=gig.GenreId,
                Heading="Edit a Gig"
               
            };
            return View("GigForm",viewModel);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userid = User.Identity.GetUserId();
            var vm = new HomeViewModel
            {
                UpcomingGigs = unitOfWork.Gig.GetUserGigs(userid),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "GIgs I'm Attending",
                Attendances = unitOfWork.Attendance.GetFutureAttendances(userid).ToLookup(g => g.GigId)
            };

            return View("Gigs", vm);
        }

        //private List<Attendence> GetFutureAttendances(string userid)
        //{
        //    return _context.Attendencies
        //      .Where(a => a.AttendeeId == userid)
        //      .ToList();
        //}

        //private List<Gig> GetUserGigs(string userid)
        //{
        //    return _context.Attendencies
        //        .Where(a => a.AttendeeId == userid)

        //        .Select(a => a.Gig)
        //        .Include(g => g.Artist)
        //        .Include(g => g.Genre)

        //        .ToList();
        //}

        [Authorize]

        public ActionResult myFollowees()
        {
            var userid = User.Identity.GetUserId();
            var myFolowees =unitOfWork.Following.GetFollowings(userid);
            return View(myFolowees);
        }

      

        [Authorize]

        public ActionResult Mine()
        {
            var userid = User.Identity.GetUserId();
            var myGigs =unitOfWork.Gig.GetGigWithArtist();
            //var myGigs = unitOfWork.Gig.GetGig();
            return View(myGigs);
        }



        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.Genres = unitOfWork.Genre.GetGenres();
                return View("GigForm", viewmodel);

            }
            var gig = new Gig
            {
                ArtistId= User.Identity.GetUserId(),
                GenreId=viewmodel.GenreId,
                DateTime=viewmodel.getDateTime(),
                Venue=viewmodel.Venue
            };
            unitOfWork.Gig.Add(gig);
            unitOfWork.Complete(); ;
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GigFormViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.Genres = unitOfWork.Genre.GetGenres();
                return View("GigForm", viewmodel);

            }
            var userid = User.Identity.GetUserId();
            var gig = unitOfWork.Gig.GetGigsWithAttendees(viewmodel.Id);
            if (gig == null)
                return HttpNotFound();
            if (gig.ArtistId != userid)
                return new HttpUnauthorizedResult();
            gig.Modify(viewmodel.getDateTime(), viewmodel.Venue, viewmodel.GenreId);
           
            
            unitOfWork.Complete();
            return RedirectToAction("Mine", "Gigs");
        }

    }
}