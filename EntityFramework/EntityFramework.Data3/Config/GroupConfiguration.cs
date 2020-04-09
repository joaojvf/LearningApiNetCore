using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Data3.Config
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
  
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(g => g.UrlPhoto)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasMany(g => g.Posts).WithOne(p => p.Group);
        }
    }
}
