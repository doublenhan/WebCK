using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.CustomAuthentication;
namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthorize(Roles = "Admin,Teacher,Student")]
        public ActionResult Index()
        {       
            return View();
        }


    }
}
