using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    public class Applicant
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }    
        public int Age { get; set; }
        public bool Hired { get; set; } = true;
    }
}
