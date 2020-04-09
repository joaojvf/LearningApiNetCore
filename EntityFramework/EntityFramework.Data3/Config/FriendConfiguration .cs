using EntityFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Data3.Config
{
    public class FriendConfiguration: IEntityTypeConfiguration<Friend>
    {
  
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasKey(a => new { a.UserId, a.UserFriendId});
        }
    }
}
