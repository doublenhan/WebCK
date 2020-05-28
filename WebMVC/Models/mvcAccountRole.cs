using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class mvcAccountRole
    {
        public int ID { get; set; }
        public int ID_Role { get; set; }
        public int ID_Account { get; set; }

        public virtual mvcAccountModel Account { get; set; }
        public virtual mvcRoleModel Role { get; set; }
    }
}