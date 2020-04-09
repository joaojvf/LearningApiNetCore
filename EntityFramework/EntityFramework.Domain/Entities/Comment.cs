using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime DatePublish { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; private set; }

        public Comment()
        {
            DatePublish = DateTime.Now;
        }

        public void SetUser (User user)
        {
            if (user != null)
            {
                User = user;
            }
        }
    }
}
