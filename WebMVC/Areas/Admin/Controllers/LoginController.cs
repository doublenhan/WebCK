using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using System.Net;
using WebMVC.Areas.Admin.Models;
using WebApi.Models;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace WebMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }      
    }
}