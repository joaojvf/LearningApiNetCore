using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace EntityFramework.Data2
{
    public class EntityFrameworkContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public EntityFrameworkContext(DbContextOptions options) : base(options)
        {

        }
    }
}
