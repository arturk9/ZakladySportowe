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
        public ActionResult AddBet(int id)
        {
            var footballMatch = _context.FootballMatches.Single(g => g.Id == id);
            var userId = User.Identity.GetUserId();

            if (
                footballMatch.Bets
                .Where(m => m.MatchId == id)
                .Where(m => m.UserId == userId)
                .ToList()
                .Count() == 0
                )
            {
                var viewModel = new BetViewModel
                {
                    MatchId = footballMatch.Id,
                    UserId = footballMatch.UserId,
                    HomeTeam = footballMatch.HomeTeam,
                    AwayTeam = footballMatch.AwayTeam
                };

                return View("BetForm", viewModel);
            }

            else { return RedirectToAction("MyBets", "Bet"); }


        }

        [Authorize]
        public ActionResult BetAScore(BetViewModel viewModel)
        {
            var Bet = new Bet
            {
                MatchId = viewModel.MatchId,
                UserId = User.Identity.GetUserId(),
                HomeTeamBetGoals = viewModel.HomeTeamBetGoals,
                AwayTeamBetGoals = viewModel.AwayTeamBetGoals

            };

            _context.Bets.Add(Bet);
            _context.SaveChanges();

            return RedirectToAction("MyBets", "Bet");
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

        [Authorize]
        [HttpPost]
        public ActionResult UpdateBet(BetViewModel viewModel)
        {
            /*if (!ModelState.IsValid)
            {
                return View("FootballMatchForm", viewModel);
            }*/

            var bet = _context.Bets.Single(g => g.BetId == viewModel.BetId);

            bet.HomeTeamBetGoals = viewModel.HomeTeamBetGoals;
            bet.AwayTeamBetGoals = viewModel.AwayTeamBetGoals;

            _context.SaveChanges();

            return RedirectToAction("MyBets", "Bet");
        }

        public ActionResult EditBet(int id)
        {
            var bet = _context.Bets
                .Include(g => g.Match)
                .Single(g => g.BetId == id);

            var viewModel = new BetViewModel
            {
                HomeTeam = bet.Match.HomeTeam,
                AwayTeam = bet.Match.AwayTeam,
                AwayTeamBetGoals = bet.AwayTeamBetGoals,
                HomeTeamBetGoals = bet.HomeTeamBetGoals
            };

            return View("BetForm", viewModel);
        }
    }
}