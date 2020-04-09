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
        public DbSet<Group> Groups { get; set; }
        public DbSet<Identification> Identification { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<LookingFor> LookingFor { get; set; }

        public EntityContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new UserGroupConfiguration());
            
            modelBuilder.ApplyConfiguration(new FriendConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new RelationshipStatusConfiguration());
            modelBuilder.ApplyConfiguration(new LookingForConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
