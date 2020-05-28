using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class mvcAccountModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mvcAccountModel()
        {
            this.AccountRoles = new HashSet<mvcAccountRole>();
        }

        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public Nullable<bool> isActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mvcAccountRole> AccountRoles { get; set; }
    }
    public class CustomSerializeModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> RoleName { get; set; }
    }


}