using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class FaculityDetail
    {
        [Key]
        public int ID { get; set; }
        public int IDFaculity { get; set; }
        [StringLength(200)]
        public string FaculityName { get; set; }
        [StringLength(200)]
        public string IndustryName { get; set; }

        public ICollection<Faculity> Faculities { get; set; }
    }
}