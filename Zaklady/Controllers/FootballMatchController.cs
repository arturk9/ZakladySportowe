using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Zaklady.Models;
using Zaklady.ViewModels;

namespace Zaklady.Controllers
{
    public class FootballMatchController : Controller
    {
        // GET: FootballMatch
        private readonly ApplicationDbContext _context;

        public FootballMatchController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult CreateFootballMatch()
        {
            var viewModel = new FootballMatchViewModel { Heading = "Dodaj mecz" };
            return View("FootballMatchForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateFootballMatch(FootballMatchViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("FootballMatchForm", viewModel);
            }

            var footballMatch = new FootballMatch
            {
                UserId = User.Identity.GetUserId(),
                Torunament = viewModel.Torunament,
                DateTime = viewModel.GetDateTime(),
                HomeTeam = viewModel.HomeTeam,
                AwayTeam = viewModel.AwayTeam
            };

            _context.FootballMatches.Add(footballMatch);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateFootballMatch(FootballMatchViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("FootballMatchForm", viewModel);
            }

            var footballMatch = _context.FootballMatches.Single(g => g.Id == viewModel.id);

            footballMatch.Torunament = viewModel.Torunament;
            footballMatch.DateTime = viewModel.GetDateTime();
            footballMatch.AwayTeam = viewModel.AwayTeam;
            footballMatch.HomeTeam = viewModel.HomeTeam;

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult EditFootballMatch(int id)
        {
            var footballMatch = _context.FootballMatches.Single(g => g.Id == id);
            var viewModel = new FootballMatchViewModel
            {
                Heading = "Edytuj mecz",
                id = footballMatch.Id,
                HomeTeam = footballMatch.HomeTeam,
                AwayTeam = footballMatch.AwayTeam,
                Date = footballMatch.DateTime.ToString("d MMM yyyy"),
                Time = footballMatch.DateTime.ToString("HH:mm"),
                Torunament = footballMatch.Torunament
            };

            return View("FootballMatchForm", viewModel);
        }

        [Authorize]
        public ActionResult RemoveFootballMatch(FootballMatchViewModel viewModel)
        {
            var footballMatch = _context.FootballMatches.Single(g => g.Id == viewModel.id);
            _context.FootballMatches.Remove(footballMatch);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddFootballMatchResult(FootballMatchViewModel viewModel)
        {
            /*if (!ModelState.IsValid)
            {
                return View("FootballMatchResults", viewModel);
            }*/

            var footballMatch = _context.FootballMatches.Single(g => g.Id == viewModel.id);
            footballMatch.HomeTeamGoals = viewModel.HomeTeamGoals;
            footballMatch.AwayTeamGoals = viewModel.AwayTeamGoals;
            footballMatch.PointsForBetingExactTeamScores = viewModel.PointsForBetingExactTeamScores;
            footballMatch.PointsForBetingMatchResult = viewModel.PointsForBetingMatchResult;

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult FillFootballMatchResult(int id)
        {
            var footballMatch = _context.FootballMatches.Single(g => g.Id == id);
            var viewModel = new FootballMatchViewModel {
                Heading = "Uzupełnij wynik meczu",
                HomeTeam = footballMatch.HomeTeam,
                AwayTeam = footballMatch.AwayTeam,
                HomeTeamGoals = footballMatch.HomeTeamGoals,
                AwayTeamGoals = footballMatch.AwayTeamGoals,
                PointsForBetingExactTeamScores = footballMatch.PointsForBetingExactTeamScores,
                PointsForBetingMatchResult = footballMatch.PointsForBetingMatchResult
            };
            return View("FootballMatchResults", viewModel);
        }
    }
}