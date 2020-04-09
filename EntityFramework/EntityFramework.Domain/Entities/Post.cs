using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Domain.Entities
{
    public class Post
    {
        public int Id{ get; set; }
        public DateTime DatePublish { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
