using EntityFramework.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UrlPhoto { get; set; }
        public SexEnum Sex { get; set; }
        public DateTime DateBirth { get; set; }
        public virtual Identification Identification { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
