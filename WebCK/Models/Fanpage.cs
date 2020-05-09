using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class Fanpage
    {
        [Key]
        public int ID { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}