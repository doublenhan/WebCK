using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Email")]
        [StringLength(255)]
        public string EMAIL { get; set; }

        public string PASSWORD { get; set; }
        
        public Role Roles { get; set; }
    }
}