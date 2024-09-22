using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency2.Models;

namespace TravelAgency2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Putovanja> Putovanja { get; set; }
        public DbSet<Aerodrom> Aerodrom { get; set; }
        public DbSet<Zemlja> Zemlja { get; set; }
    }
}
