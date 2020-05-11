using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class IndustryofFaculity
    {
        [Key]
        public int ID { get; set; }
        public int FaculityID { get; set; }
        [StringLength(200)]
        public string IndustryName { get; set; }
        public Faculity Faculities { get; set; }

        public  ICollection<Student> Students { get; set; }
    }
}