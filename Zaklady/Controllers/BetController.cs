using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Zaklady.Models;
using Zaklady.ViewModels;

namespace Zaklady.Controllers
{
    public class BetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BetController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult PopulateBetForm(int id)
        {
            var footballMatch = _context.FootballMatches.Single(g => g.Id == id);
            var userId = User.Identity.GetUserId();

            if (
                footballMatch.Bets
                .Where(m => m.MatchId == id)
                .Where(m => m.UserId == userId)
                .ToList()
                .Any()//wczesniej bylo count=0
                )
            {
                var viewModel = new BetViewModel
                {
                    MatchId = footballMatch.Id,
                    UserId = footballMatch.UserId,
                    HomeTeamName = footballMatch.HomeTeamName,
                    AwayTeamName = footballMatch.AwayTeamName
                };

                return View("BetForm", viewModel);
            }

            else { return RedirectToAction("MyBets", "Bet"); }


        }

        [Authorize]
        public ActionResult InsertBetRecordToDatabase(BetViewModel viewModel)
        {
            var bet = new Bet
            {
                MatchId = viewModel.MatchId,
                UserId = User.Identity.GetUserId(),
                BetHomeTeamGoals = viewModel.BetHomeTeamGoals,
                BetAwayTeamGoals = viewModel.BetAwayTeamGoals

            };

            _context.Bets.Add(bet);
            _context.SaveChanges();

            return RedirectToAction("MyBets", "Bet");
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateBetRecord(BetViewModel viewModel)
        {
            /*if (!ModelState.IsValid)
            {
                return View("FootballMatchForm", viewModel);
            }*/

            var bet = _context.Bets.Single(g => g.BetId == viewModel.BetId);

            bet.BetHomeTeamGoals = viewModel.BetHomeTeamGoals;
            bet.BetAwayTeamGoals = viewModel.BetAwayTeamGoals;

            _context.SaveChanges();

            return RedirectToAction("MyBets", "Bet");
        }

        public ActionResult PopulateEditBetForm(int id)
        {
            var bet = _context.Bets
                .Include(g => g.Match)
                .Single(g => g.BetId == id);

            var viewModel = new BetViewModel
            {
                HomeTeamName = bet.Match.HomeTeamName,
                AwayTeamName = bet.Match.AwayTeamName,
                BetAwayTeamGoals = bet.BetAwayTeamGoals,
                BetHomeTeamGoals = bet.BetHomeTeamGoals
            };

            return View("BetForm", viewModel);
        }

        [Authorize]
        public ActionResult MyBets()
        {
            var userId = User.Identity.GetUserId();

            var bets = _context.Bets
                .Include(t => t.Match)
                .Include(t => t.User)
                .Where(t => t.UserId == userId)
                .ToList();

            return View(bets);
        }
    }
}