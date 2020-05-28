using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApi.Models;

namespace WebMVC.CustomAuthentication
{
    public class CustomMembershipUser : MembershipUser
    {
        #region user Properties  

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<AccountRole> Roles { get; set; }

        #endregion

        public CustomMembershipUser(Account user) : base("CustomMembership", user.UserName, user.ID, user.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            ID = user.ID;
            FirstName = user.FristName;
            LastName = user.LastName;
            Roles = user.AccountRoles;
        }
    }
}