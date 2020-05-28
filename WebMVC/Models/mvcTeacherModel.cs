using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class mvcTeacherModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mvcTeacherModel()
        {
            this.Subjects = new HashSet<mvcSubjectModel>();
        }

        public int ID { get; set; }
        public string FullName { get; set; }
        public string MSGV { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DateBegin { get; set; }
        public Nullable<int> ID_Roles { get; set; }
        public Nullable<int> ID_Faculity { get; set; }
        public Nullable<int> ID_Subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mvcSubjectModel> Subjects { get; set; }
    }

}