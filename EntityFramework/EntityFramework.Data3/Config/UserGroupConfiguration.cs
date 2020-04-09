using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Data3.Config
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
  
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasKey(u => new { u.UserId, u.GroupId });
            builder.Property(u => u.DateCreation)
                .IsRequired();
            builder.Property(u => u.IsAdmin);
        }
    }
}
