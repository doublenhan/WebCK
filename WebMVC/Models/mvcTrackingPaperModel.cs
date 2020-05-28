using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class mvcTrackingPaperModel
    {
        public int ID { get; set; }
        public string Contents { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> TrackingTime { get; set; }
        public Nullable<int> ID_Student { get; set; }
        public Nullable<int> ID_Subject { get; set; }
        public string FileUpload { get; set; }

        public virtual mvcStudentModel Student { get; set; }
        public virtual mvcSubjectModel Subject { get; set; }
    }
}