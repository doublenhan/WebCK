using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Areas.Admin.Models
{
    public class mvcAccountModel
    {
        public int ID_Account { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public Nullable<int> ID_Roles { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }

        
    }
}