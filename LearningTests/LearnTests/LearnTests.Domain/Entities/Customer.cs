using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LearnTests.Domain.Entities
{
    public class Customer
    {
        [MinLength(4, ErrorMessage = "O nome deve ter pelo menos 5 caracteres.")]
        [MaxLength(60, ErrorMessage = "O nome deve ter no máximo 60 caracteres.")]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
