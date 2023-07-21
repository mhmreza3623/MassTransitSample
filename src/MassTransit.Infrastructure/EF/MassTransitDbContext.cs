using Microsoft.EntityFrameworkCore;

namespace MassTransit.Infrastructure.EF
{
    public class MassTransitDbContext : DbContext
    {
        public MassTransitDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
