using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Data3.Config
{
    public class RelationshipStatusConfiguration : IEntityTypeConfiguration<RelationshipStatus>
    {
  
        public void Configure(EntityTypeBuilder<RelationshipStatus> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Description);

            builder.HasData(
                new LookingFor() { Id = 1, Description = "NotSpecified" },
                new LookingFor() { Id = 2, Description = "Single" },
                new LookingFor() { Id = 3, Description = "Married" },
                new LookingFor() { Id = 4, Description = "InSeriousRelationship" }
                );
        }
    }
}
