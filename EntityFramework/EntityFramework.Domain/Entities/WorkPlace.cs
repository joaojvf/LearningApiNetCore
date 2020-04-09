using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Domain.Entities
{
    public class WorkPlace
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Name { get; set; }
        public DateTime DateAdmission { get; set; }
        public DateTime? DateOut { get; set; }
        public bool CurrentCompany { get; set; }
    }
}
