using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }

        [StringLength (50)]
        public string RoleName { get; set; }
    }
}