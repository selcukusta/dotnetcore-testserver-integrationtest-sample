using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace app.models.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Fullname => $"{Name} {Surname}";
        [Required(ErrorMessage = "Identification number can not be null!")]
        [MinLength(11, ErrorMessage = "Invalid identification number")]
        [MaxLength(11, ErrorMessage = "Invalid identification number")]
        [RegularExpression(@"\d{11}", ErrorMessage = "Invalid identification number")]
        public string IdentificationNumber { get; set; }
    }
}
