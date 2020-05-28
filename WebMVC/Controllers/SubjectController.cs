using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
using WebMVC.Models;
using WebMVC.CustomAuthentication;
namespace WebMVC.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        // GET: Admin/Subject      
        public ActionResult Index()
        {
            IEnumerable<mvcSubjectModel> stuSub;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Subjects").Result;
            stuSub = response.Content.ReadAsAsync<IEnumerable<mvcSubjectModel>>().Result;
            return View(stuSub);
        }
        public ActionResult create(int id = 0)
        {
            return View(new mvcSubjectModel());
        }     
        [HttpPost]
        public ActionResult Create(mvcSubjectModel sub)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Subjects", sub).Result;
            TempData["SuccessMessage"] = " Lưu Thành Công";
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles ="Teacher")]
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Subjects/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcSubjectModel>().Result);
            }
        }
       
        [HttpPost]
        public ActionResult Edit(mvcSubjectModel sub)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Subjects/" + sub.ID, sub).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = " Chỉnh Sửa Thành Công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View(sub);
        }
    }
}