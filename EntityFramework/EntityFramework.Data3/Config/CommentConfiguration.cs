using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Data3.Config
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
  
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DatePublish)
                .IsRequired();
            builder.Property(c => c.Text)
                .IsRequired()
                .HasMaxLength(600);
        }
    }
}
