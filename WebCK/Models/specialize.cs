using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class Specialize
    {
        [Key]
        public int ID { get; set; }

        [StringLength(250)]
        public string IndustryName { get; set; }
    }
}  