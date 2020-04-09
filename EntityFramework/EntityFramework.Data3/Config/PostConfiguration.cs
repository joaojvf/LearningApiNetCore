using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Data3.Config
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DatePublish)
                .IsRequired();
            builder.Property(p => p.Text)
                .IsRequired()
                .HasMaxLength(400);

            builder.HasOne(p => p.User).WithMany(u => u.Posts);

        }
    }
}
