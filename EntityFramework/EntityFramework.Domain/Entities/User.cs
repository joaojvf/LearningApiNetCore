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
        public virtual RelationshipStatus RelationshipStatus { get; set; }
        public virtual LookingFor LookingFor { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<WorkPlace> WorkPlaces{ get; set; }
        public virtual ICollection<EducationalInstitution> EducationalInstitutions { get; set; }
        public virtual ICollection<Friend> Friends{ get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public User()
        {
            Posts = new List<Post>();
            UserGroups = new List<UserGroup>();
            WorkPlaces = new List<WorkPlace>();
            EducationalInstitutions = new List<EducationalInstitution>();
            Friends = new List<Friend>();
            Comments = new List<Comment>();
        }
    }
}
