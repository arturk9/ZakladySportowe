using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Zaklady.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<FootballMatch> FootballMatches { get; set; }
        public DbSet<FootballMatchResults> FootballMatchResult { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}