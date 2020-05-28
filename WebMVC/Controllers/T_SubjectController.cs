using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
using WebMVC.CustomAuthentication;
using WebMVC.Models;
namespace WebMVC.Controllers
{

    public class T_SubjectController : Controller
    {        
        
        [CustomAuthorize(Roles = "Admin,Teacher,HeaderFaulity,Secretary,Student")]
        // GET: T_Subject
        public ActionResult Index()
        {
            IEnumerable<mvcT_SubjectModel> tsub;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("T_Subject").Result;
            tsub = response.Content.ReadAsAsync<IEnumerable<mvcT_SubjectModel>>().Result;
            return View(tsub);
            
        }
        public ActionResult create(int id = 0)
        {
            return View(new mvcT_SubjectModel());
        }
        [HttpPost]
        public ActionResult Create(mvcT_SubjectModel tsub)
        {           
            HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("T_Subject", tsub).Result;
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
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("T_Subject/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcT_SubjectModel>().Result);
            }
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(mvcT_SubjectModel tsub)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("T_Subject/" + tsub.ID, tsub).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = " Chỉnh Sửa Thành Công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View(tsub);
        }
        public ActionResult Details(int id )
        {
            mvcT_SubjectModel tsubDetails = null;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("T_Subject/" + id.ToString()).Result;
            tsubDetails = response.Content.ReadAsAsync<mvcT_SubjectModel>().Result;
            return View(tsubDetails);
        }
        public ActionResult Delete(int id )
        {
            mvcT_SubjectModel tsubDetails = null;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("T_Subject/" + id.ToString()).Result;
            tsubDetails = response.Content.ReadAsAsync <mvcT_SubjectModel>().Result;
            return View(tsubDetails);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(mvcT_SubjectModel tsub)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("T_Subject/" + tsub.ID).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Xóa Thành Công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View(tsub);
        }
    }
}