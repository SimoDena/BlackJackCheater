using Microsoft.EntityFrameworkCore;

namespace BlackJackCheater.Models
{
    public class BlackJackDbContext : DbContext
    {
        public BlackJackDbContext(DbContextOptions<BlackJackDbContext> options): base(options)
        {

        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
