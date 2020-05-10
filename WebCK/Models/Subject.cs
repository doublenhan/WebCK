using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class Subject
    {
        
        [Key]
        public int ID { get; set; }
        [Display (Name ="Tên Đề Tài")]
        [StringLength (100)]
        public string SubjectName { get; set; }

        [StringLength(150)]
        public string Content { get; set; }
 
        public string Description { get; set; }
        
    }
}