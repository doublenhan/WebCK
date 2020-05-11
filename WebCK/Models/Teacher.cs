using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    public class Teacher
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ Tên")]
        public string FullName { get; set; }

        [Display(Name = "Khoa")]
        public int IDFaculity { get; set; }

        [StringLength(9)]
        [Display(Name = "Mã Số Giảng Viên")]
        public string MSGV { get; set; }


        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [Display(Name = "Ngày Sinh")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYSINH { get; set; }

        [Display(Name = "Số Điện Thoại")]
        [StringLength(13)]
        public string SDT { get; set; }

        [Display(Name = "Email")]
        [StringLength(255)]
        public string EMAIL { get; set; }

        [Display(Name = "Giới Tính")]
        public bool? GIOITINH { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DATEBEGIN { get; set; }
        //public int ID_QUYEN { get; set; }
        public Role Roles { get; set; }
        public Faculity Faculities { get; set; }

        public  ICollection<Subject> Subjects { get; set; }

        
    }
}