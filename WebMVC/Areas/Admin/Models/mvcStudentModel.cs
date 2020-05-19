using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebMVC.Areas.Admin.Models
{
    public class mvcStudentModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string MSSV { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Class { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public decimal NumberPhone { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public Nullable<System.DateTime> DateBegin { get; set; }
        public Nullable<int> ID_Faculity { get; set; }
        public Nullable<int> ID_IndustryofFaculity { get; set; }
        public Nullable<int> ID_Subject { get; set; }
    }
}