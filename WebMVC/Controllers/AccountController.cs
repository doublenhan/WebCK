using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMVC.CustomAuthentication;
namespace WebMVC.Controllers
{
    
    public class AccountController : Controller
    {
        [CustomAuthorize(Roles = "User")]
        public ActionResult Index()
        {
            return View();
        }
    }
}