using MassTransit.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MassTransit.Infrastructure.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TopicTagEntity>()
                   .HasOne(w => w.Tag)
                   .WithMany(q => q.Topics)
                   .HasForeignKey(w => w.TagId);

            modelBuilder.Entity<TopicTagEntity>()
                   .HasOne(w => w.Topic)
                   .WithMany(q => q.Tags)
                   .HasForeignKey(w => w.TopicId);

            modelBuilder.Entity<TopicTagEntity>().HasKey(w => new { w.TagId, w.TopicId });

            modelBuilder.Entity<EventBusEntity>().HasKey(q => q.Id);
        }

        public DbSet<TopicEntity> Topics { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<TopicTagEntity> TopicTags { get; set; }
        public DbSet<EventBusEntity> Events { get; set; }
    }
}
