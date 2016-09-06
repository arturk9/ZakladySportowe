using System.Linq;
using System.Web.Mvc;
using Zaklady.Models;
using Zaklady.ViewModels;

namespace Zaklady.Controllers
{
    public class RankingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RankingController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Ranking
        public ActionResult RankingsIndex()
        {
            var usersList = _context.Users.ToList();
            var betsList = _context.Bets.ToList();

            var usersViewModel = new UsersViewModel
            {
                UsersList = usersList
            };

            usersViewModel.SetUsersPoints(usersList, betsList);

            return View(usersViewModel);
        }
    }
}