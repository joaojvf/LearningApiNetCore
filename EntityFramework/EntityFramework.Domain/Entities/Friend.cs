using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Domain.Entities
{
    public class Friend
    {
        public virtual int UserId { get; set; }
        public virtual User User{ get; set; }
        public virtual User UserFriend{ get; set; }
        public int UserFriendId { get; set; }
    }
}
