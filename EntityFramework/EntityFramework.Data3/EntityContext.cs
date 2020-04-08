using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Infra.Data3
{
    public class EntityContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public EntityContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
