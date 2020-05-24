using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult create(int id = 0)
        {
            return View(new mvcStudentModel());
        }
        [HttpPost]
        public ActionResult Create(mvcStudentModel stu)
        {   
            HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Students", stu).Result;
            TempData["SuccessMessage"] = " Lưu Thành Công";
            return RedirectToAction("Index");
        }       
        public ActionResult Edit (int id = 0)
        {
            if(id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Students/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcStudentModel>().Result);
            }             
        }
        [HttpPost]
        public ActionResult Edit(mvcStudentModel stu)
        {                       
            HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Students/" + stu.ID, stu).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = " Chỉnh Sửa Thành Công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View(stu);
        }

        
        public ActionResult Details (int id = 0)
        {
            //if (id == 0)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //else
            //{
            //    HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Students/" + id.ToString()).Result;
            //    return View(response.Content.ReadAsAsync<mvcStudentModel>().Result);
            //}
            mvcStudentModel stuDetails = null;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Students/" + id.ToString()).Result;
            stuDetails = response.Content.ReadAsAsync<mvcStudentModel>().Result;
            return View(stuDetails);
        }

        //public ActionResult Delete(int id)
        //{
        //    HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("Students/" + id.ToString()).Result;
        //    TempData["SuccessMessage"] = " Xóa Thành Công";
        //    return RedirectToAction("Index");
        //}

    }
}