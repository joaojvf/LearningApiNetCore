using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Data3.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasMaxLength(400).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(400).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(400).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(400).IsRequired();
            builder.Property(u => u.Sex).IsRequired();
            builder.Property(u => u.UrlPhoto).HasMaxLength(400).IsRequired();
            builder.Property(u => u.DateBirth).IsRequired();
            builder.HasOne(u => u.Identification)
                   .WithOne(i => i.User)
                   .HasForeignKey<Identification>(i => i.UserId);

            builder.HasMany(u => u.Posts).WithOne(p => p.User);
            builder.HasMany(u => u.Comments).WithOne(c => c.User);
            builder.HasMany(u => u.Friends).WithOne(c => c.User);
            builder.HasMany(u => u.Posts).WithOne(c => c.User);
            builder.HasMany(u => u.UserGroups).WithOne(c => c.User);

            builder.HasOne(u => u.RelationshipStatus);
            builder.HasOne(u => u.LookingFor);
        }
    }
}
