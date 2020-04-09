using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Domain.Entities
{
    public class UserGroup
    {
        public DateTime DateCreation { get; set; }
        public bool IsAdmin { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int  GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
