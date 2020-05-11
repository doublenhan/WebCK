using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class Faculity
    {
        [Key]
        public int ID { get; set; }
        [StringLength(200)]
        public string FaculityName { get; set; } 

        public  ICollection<IndustryofFaculity> IndustryofFaculities { get; set; }

        public  ICollection<Student> Students { get; set; }

        public  ICollection<Teacher> Teachers { get; set; }
    }
}