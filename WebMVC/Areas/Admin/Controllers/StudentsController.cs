using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebMVC.Areas.Admin.Models;

namespace WebMVC.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Admin/Students
        public ActionResult Index()
        {
            IEnumerable<mvcStudentModel> stuList;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Students").Result;
            stuList = response.Content.ReadAsAsync<IEnumerable<mvcStudentModel>>().Result;
            return View(stuList);
        }
        public ActionResult Create(int id = 0)
        {
            return View(new mvcStudentModel());
        }
        [HttpPost]
        public ActionResult Create(mvcStudentModel stu)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Students",stu).Result;
            TempData["SuccessMessage"] = " Lưu Thành Công";
            return RedirectToAction("Index");
        }
    }
}