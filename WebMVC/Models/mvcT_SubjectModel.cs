using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class mvcT_SubjectModel
    {
        public int ID { get; set; }
        public string ID_Subject { get; set; }
        public string T_SubjectName { get; set; }
        public string Contents { get; set; }
        public string Description { get; set; }
        public Nullable<int> ID_Teacher { get; set; }
        public virtual mvcTeacherModel Teacher { get; set; }
    }
}