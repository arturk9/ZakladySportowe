using System.Linq;
using System.Web.Mvc;
using Zaklady.Models;
using Zaklady.ViewModels;

namespace Zaklady.Controllers
{
    public class RankingController : Controller
    {
        private ApplicationDbContext _context;

        public RankingController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Ranking
        public ActionResult RankingsIndex()
        {
            var usersList = _context.Users.ToList();

            var usersViewModel = new UsersViewModel
            {
                UsersList = usersList
            };

            return View(usersViewModel);
        }
    }
}