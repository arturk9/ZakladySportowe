using System.Web.Mvc;
using Zaklady.Models;

namespace Zaklady.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            var upcomingMatches = _context.FootballMatches;
            return View(upcomingMatches);
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