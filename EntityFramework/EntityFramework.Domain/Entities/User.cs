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
        public string UrlPhoto { get; set; }
        public SexEnum Sex { get; set; }
    }
}
