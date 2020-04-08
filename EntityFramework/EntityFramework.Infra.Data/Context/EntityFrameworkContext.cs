using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Infra.Data.Context
{
    public class EntityFrameworkContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public EntityFrameworkContext(DbContextOptions options) : base(options)
        {

        }
    }
}
