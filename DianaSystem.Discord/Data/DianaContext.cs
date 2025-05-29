using DianaSystem.Discord.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DianaSystem.Discord.Data
{
    public class DianaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DianaContext(DbContextOptions<DianaContext> options) : base(options) {}        
    }
}
