using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;
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
        public ActionResult InsertFootballMatchRecord(FootballMatchViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("FootballMatchForm", viewModel);
            }

            var footballMatch = new FootballMatch
            {
                UserId = User.Identity.GetUserId(),
                TorunamentName = viewModel.TorunamentName,
                DateTime = viewModel.GetDateTime(),
                HomeTeamName = viewModel.HomeTeamName,
                AwayTeamName = viewModel.AwayTeamName
            };

            _context.FootballMatches.Add(footballMatch);
            _context.SaveChanges();

            return RedirectToAction("UpcomingEvents", "FootballMatch");
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateFootballMatchDatabaseRecord(FootballMatchViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("FootballMatchForm", viewModel);
            }

            var footballMatch = _context.FootballMatches.Single(g => g.Id == viewModel.Id);

            footballMatch.TorunamentName = viewModel.TorunamentName;
            footballMatch.DateTime = viewModel.GetDateTime();
            footballMatch.AwayTeamName = viewModel.AwayTeamName;
            footballMatch.HomeTeamName = viewModel.HomeTeamName;

            _context.SaveChanges();

            return RedirectToAction("UpcomingEvents", "FootballMatch");
        }

        [Authorize]
        public ActionResult EditFootballMatch(int id)
        {
            var footballMatch = _context.FootballMatches.Single(g => g.Id == id);
            var viewModel = new FootballMatchViewModel
            {
                Heading = "Edytuj mecz",
                Id = footballMatch.Id,
                HomeTeamName = footballMatch.HomeTeamName,
                AwayTeamName = footballMatch.AwayTeamName,
                Date = footballMatch.DateTime.ToString("d MMM yyyy"),
                Time = footballMatch.DateTime.ToString("HH:mm"),
                TorunamentName = footballMatch.TorunamentName
            };

            return View("FootballMatchForm", viewModel);
        }

        [Authorize]
        public ActionResult FootballMatchRemovalConfirmation(int id)
        {
            var footballMatch = _context.FootballMatches.Single(g => g.Id == id);
            var viewModel = new FootballMatchViewModel
            {
                Heading = "Edytuj mecz",
                Id = footballMatch.Id,
                HomeTeamName = footballMatch.HomeTeamName,
                AwayTeamName = footballMatch.AwayTeamName,
                Date = footballMatch.DateTime.ToString("d MMM yyyy"),
                Time = footballMatch.DateTime.ToString("HH:mm"),
                TorunamentName = footballMatch.TorunamentName
            };

            return View("DeleteBetConfirmation", viewModel);
        }

        [Authorize]
        public ActionResult RemoveFootballMatchRecord(FootballMatchViewModel viewModel)
        {
            var footballMatch = _context.FootballMatches.Single(g => g.Id == viewModel.Id);

            try
            {
                var bet = _context.Bets.Single(g => g.MatchId == viewModel.Id);
                _context.Bets.Remove(bet);
                _context.SaveChanges();
                _context.FootballMatches.Remove(footballMatch);
                _context.SaveChanges();
            }
            catch
            {
                _context.FootballMatches.Remove(footballMatch);
                _context.SaveChanges();
            }

            return RedirectToAction("UpcomingEvents", "FootballMatch");
        }

        public ActionResult AddFootballMatchResultToDatabaseAndSetPointsForBet(FootballMatchViewModel viewModel)
        {
            /*if (!ModelState.IsValid)
            {
                return View("FootballMatchResults", viewModel);
            }*/

            /*
             * Conditional below compares users bet and real football match result
             * 
             * It was set to award user with points in two cases:
             * 
             * 1) correct prediction of exact goals scored by both teams
             * -  User is awarded when both team scored goals are equal to his predictions
             * 
             * 2) correct prediction of match result (the right team won or match ended up with a draw)
             * -  User is awarded when:
             *    Home Team won and user predicted Home Team to win, but goals scored and predicted are not equal - OR -
             *    Away Team won and user predicted Away Team to win, but goals scored and predicted are not equal - OR -
             *    Match ended up with a draw and user predicted a draw, but goals scored and predicted are not equal
             *    and in addition, the conditional 1) wasnt true
             * 
             * If both 1) and 2) conditions are false, points for betting are supposed to be equal to their default value (its 0)
             * 
             */

            var footballMatch = _context.FootballMatches.Single(g => g.Id == viewModel.Id);
            footballMatch.HomeTeamGoals = viewModel.HomeTeamGoals;
            footballMatch.AwayTeamGoals = viewModel.AwayTeamGoals;
            footballMatch.PointsForBettingExactTeamScores = viewModel.PointsForBettingExactTeamScores;
            footballMatch.PointsForBettingCorrectMatchResult = viewModel.PointsForBettingCorrectMatchResult;

            var bets = _context.Bets.Where(m => m.MatchId == footballMatch.Id).ToList();

            foreach (var item in bets)
            {
                if (item.Match.HomeTeamGoals == item.BetHomeTeamGoals && item.Match.AwayTeamGoals == item.BetAwayTeamGoals)
                    item.Points = footballMatch.PointsForBettingExactTeamScores;

                else if (
                    (
                        ((item.BetHomeTeamGoals > item.BetAwayTeamGoals) & (item.Match.AwayTeamGoals < item.Match.HomeTeamGoals))
                        | ((item.BetHomeTeamGoals == item.BetAwayTeamGoals) & (item.Match.AwayTeamGoals == item.Match.HomeTeamGoals))
                        | ((item.BetHomeTeamGoals < item.BetAwayTeamGoals) & (item.Match.AwayTeamGoals > item.Match.HomeTeamGoals))
                    )
                        & (item.BetHomeTeamGoals != item.Match.HomeTeamGoals
                        & item.BetAwayTeamGoals != item.Match.AwayTeamGoals)
                        )
                {
                    item.Points = footballMatch.PointsForBettingCorrectMatchResult;
                }
            }

            _context.SaveChanges();

            return RedirectToAction("UpcomingEvents", "FootballMatch");
        }

        [Authorize]
        public ActionResult AddFootballMatchResult(int id)
        {
            var footballMatch = _context.FootballMatches.Single(g => g.Id == id);
            var viewModel = new FootballMatchViewModel
            {
                Heading = "Uzupełnij wynik meczu",
                HomeTeamName = footballMatch.HomeTeamName,
                AwayTeamName = footballMatch.AwayTeamName,
                HomeTeamGoals = footballMatch.HomeTeamGoals,
                AwayTeamGoals = footballMatch.AwayTeamGoals,
                PointsForBettingExactTeamScores = footballMatch.PointsForBettingExactTeamScores,
                PointsForBettingCorrectMatchResult = footballMatch.PointsForBettingCorrectMatchResult
            };
            return View("FootballMatchResults", viewModel);
        }

        public ViewResult UpcomingEvents(int? page)
        {
            var upcomingMatches = _context.FootballMatches.OrderBy(m => m.DateTime);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(upcomingMatches.ToPagedList(pageNumber, pageSize));
        }
    }
}