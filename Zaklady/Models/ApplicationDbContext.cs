using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Zaklady.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<FootballMatch> FootballMatches { get; set; }
        public DbSet<Bet> Bets { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}