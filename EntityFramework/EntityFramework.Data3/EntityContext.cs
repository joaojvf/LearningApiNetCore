using EntityFramework.Data3.Config;
using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Infra.Data3
{
    public class EntityContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<RelationshipStatus> RelationshipStatus { get; set; }

        public EntityContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
