using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebCK.Models;

namespace WebCK.Controllers
{
    public class IndustryofFaculitiesController : ApiController
    {
        private ServerDBContext db = new ServerDBContext();

        // GET: api/IndustryofFaculities
        public IQueryable<IndustryofFaculity> GetFaculityDetails()
        {
            return db.FaculityDetails;
        }

        // GET: api/IndustryofFaculities/5
        [ResponseType(typeof(IndustryofFaculity))]
        public IHttpActionResult GetIndustryofFaculity(int id)
        {
            IndustryofFaculity industryofFaculity = db.FaculityDetails.Find(id);
            if (industryofFaculity == null)
            {
                return NotFound();
            }

            return Ok(industryofFaculity);
        }

        // PUT: api/IndustryofFaculities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIndustryofFaculity(int id, IndustryofFaculity industryofFaculity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != industryofFaculity.ID)
            {
                return BadRequest();
            }

            db.Entry(industryofFaculity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryofFaculityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/IndustryofFaculities
        [ResponseType(typeof(IndustryofFaculity))]
        public IHttpActionResult PostIndustryofFaculity(IndustryofFaculity industryofFaculity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FaculityDetails.Add(industryofFaculity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = industryofFaculity.ID }, industryofFaculity);
        }

        // DELETE: api/IndustryofFaculities/5
        [ResponseType(typeof(IndustryofFaculity))]
        public IHttpActionResult DeleteIndustryofFaculity(int id)
        {
            IndustryofFaculity industryofFaculity = db.FaculityDetails.Find(id);
            if (industryofFaculity == null)
            {
                return NotFound();
            }

            db.FaculityDetails.Remove(industryofFaculity);
            db.SaveChanges();

            return Ok(industryofFaculity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IndustryofFaculityExists(int id)
        {
            return db.FaculityDetails.Count(e => e.ID == id) > 0;
        }
    }
}