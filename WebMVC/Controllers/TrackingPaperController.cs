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
using System.IO;
using System.Configuration;

namespace WebMVC.Controllers
{
    [Authorize]
    public class TrackingPaperController : Controller
    {
        // GET: TrackingPaper      
        [CustomAuthorize(Roles = "Admin,Teacher,HeaderFaulity,Secretary,Student")]
        public ActionResult Index()
        {
            IEnumerable<mvcTrackingPaperModel> tp;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("TrackingPapers").Result;
            tp = response.Content.ReadAsAsync<IEnumerable<mvcTrackingPaperModel>>().Result;
            return View(tp);

        }
        [CustomAuthorize(Roles = "Student")]
        public ActionResult create(int id = 0)
        {
            return View(new mvcTrackingPaperModel());
        }
        [CustomAuthorize(Roles = "Student")]
        [HttpPost]
        public ActionResult Create(mvcTrackingPaperModel tp, HttpPostedFileBase file)
        {          
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("TrackingPapers", tp).Result;
                return RedirectToAction("Index");
                    
        }
        [CustomAuthorize(Roles = "Student")]
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("TrackingPapers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcTrackingPaperModel>().Result);
            }
        }
        [CustomAuthorize(Roles = "Student")]
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(mvcTrackingPaperModel tp)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("TrackingPapers/" + tp.ID, tp).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = " Chỉnh Sửa Thành Công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View(tp);
        }    
        public ActionResult Delete(int id)
        {
            mvcTrackingPaperModel tpDetails = null;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("TrackingPapers/" + id.ToString()).Result;
            tpDetails = response.Content.ReadAsAsync<mvcTrackingPaperModel>().Result;
            return View(tpDetails);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(mvcTrackingPaperModel tp)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("TrackingPapers/" + tp.ID).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Xóa Thành Công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View(tp);     
        }     
    }
}