using Microsoft.EntityFrameworkCore;
using Hotelo.Core;

namespace Hotelo.Data
{
    public class HoteloDbContext : DbContext
    {
        public HoteloDbContext(DbContextOptions<HoteloDbContext> options) : base(options)
        {
            
        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
