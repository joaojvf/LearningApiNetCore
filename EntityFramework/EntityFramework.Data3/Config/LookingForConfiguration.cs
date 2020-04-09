using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Data3.Config
{
    public class LookingForConfiguration : IEntityTypeConfiguration<LookingFor>
    {
  
        public void Configure(EntityTypeBuilder<LookingFor> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Description);

            builder.HasData(
                new LookingFor() { Id = 1, Description = "NotSpecified" },
                new LookingFor() { Id = 2, Description = "Dating" },
                new LookingFor() { Id = 3, Description = "Friefriendship" },
                new LookingFor() { Id = 4, Description = "SeriousRelationship" }
                );
        }
    }
}
