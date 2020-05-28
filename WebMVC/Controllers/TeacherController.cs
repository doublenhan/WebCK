using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Admin/Teacher
        public ActionResult Index()
        {
            IEnumerable<mvcTeacherModel> teaList;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Teachers").Result;
            teaList = response.Content.ReadAsAsync<IEnumerable<mvcTeacherModel>>().Result;
            return View(teaList);
        }
        public ActionResult create(int id = 0)
        {
            return View(new mvcTeacherModel());
        }
        [HttpPost]
        public ActionResult Create(mvcTeacherModel tea)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Teachers", tea).Result;
            TempData["SuccessMessage"] = " Lưu Thành Công";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Teachers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcTeacherModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult Edit(mvcTeacherModel tea)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Teachers/" + tea.ID, tea).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = " Chỉnh Sửa Thành Công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View(tea);
        }
        public ActionResult Details(int id = 0)
        {      
            mvcTeacherModel teaDetails = null;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Teachers/" + id.ToString()).Result;
            teaDetails = response.Content.ReadAsAsync<mvcTeacherModel>().Result;
            return View(teaDetails);
        }
    }
}