using SpisZaginionychOsobMVC.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpisZaginionychOsobMVC.Models
{
    public class LostPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Range(0,130)]
        public int Age { get; set; }
        public Genders Gender { get; set; }
        public string Description { get; set; }
    }
}