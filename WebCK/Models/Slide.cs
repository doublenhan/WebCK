using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class Slide
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        
        public string Link { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
    }
}