using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class user
    { 
        [Key]
        public int ID { get; set; }
        
        [StringLength (50)]
        [Display(Name ="Họ Tên")]
        public string FullName { get; set; }

        [StringLength(9)]
        [Display(Name = "Mã Số Sinh Viên")]
        public string MSSV { get; set; }

        [StringLength(9)]
        [Display(Name = "Lớp")]
        public string Classs { get; set; }

        [StringLength(9)]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
    }
}