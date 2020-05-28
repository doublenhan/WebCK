using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebMVC.Models
{
    public class mvcSubjectModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string ID_Subject { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string SubjectName { get; set; }
        public string Contents { get; set; }
        public string Description { get; set; }
        public Nullable<int> ID_Teacher { get; set; }
        public virtual mvcTeacherModel Teacher { get; set; }

    }
    
}