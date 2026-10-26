
using Microsoft.EntityFrameworkCore;
using Zenestudio.Models;

namespace Zenestudio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Eloado> Eloadok { get; set; }
        public DbSet<ZeneiProjekt> ZeneiProjektek { get; set; }
        public DbSet<Sav> Savok { get; set; }
    }
}
