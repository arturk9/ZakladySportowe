using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Zaklady.Models;
using Zaklady.ViewModels;

namespace Zaklady.Controllers
{
    public class FootballMatchController : Controller
    {
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

        public ActionResult AddFootballMatchResult(FootballMatchResultsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("FootballMatchResults", viewModel);
            }

            var footballMatch = _context.FootballMatches.Single(g => g.Id == viewModel.id);
            var footballMatchResults = new FootballMatchResults
            {
                HomeTeam = footballMatch.HomeTeam,
                AwayTeam = footballMatch.AwayTeam,
                UserId = User.Identity.GetUserId(),
                HomeTeamGoals = viewModel.HomeTeamGoals,
                AwayTeamGoals = viewModel.AwayTeamGoals,
                PointsForBetingExactTeamScores = viewModel.PointsForBetingExactTeamScores,
                PointsForBetingMatchResult = viewModel.PointsForBetingMatchResult
            };

            _context.FootballMatchResult.Add(footballMatchResults);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        [Authorize]
        public ActionResult FillFootballMatchResult()
        {
            var viewModel = new FootballMatchResultsViewModel { Heading = "Uzupełnij wynik meczu" };
            return View("FootballMatchResults", viewModel);
        }
    }
}