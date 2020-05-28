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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class SubjectDetailsController : ApiController
    {
        private data db = new data();

        // GET: api/SubjectDetails
        public IQueryable<SubjectDetail> GetSubjectDetails()
        {
            return db.SubjectDetails;
        }

        // GET: api/SubjectDetails/5
        [ResponseType(typeof(SubjectDetail))]
        public IHttpActionResult GetSubjectDetail(int id)
        {
            SubjectDetail subjectDetail = db.SubjectDetails.Find(id);
            if (subjectDetail == null)
            {
                return NotFound();
            }

            return Ok(subjectDetail);
        }

        // PUT: api/SubjectDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubjectDetail(int id, SubjectDetail subjectDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectDetail.ID)
            {
                return BadRequest();
            }

            db.Entry(subjectDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectDetailExists(id))
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

        // POST: api/SubjectDetails
        [ResponseType(typeof(SubjectDetail))]
        public IHttpActionResult PostSubjectDetail(SubjectDetail subjectDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubjectDetails.Add(subjectDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subjectDetail.ID }, subjectDetail);
        }

        // DELETE: api/SubjectDetails/5
        [ResponseType(typeof(SubjectDetail))]
        public IHttpActionResult DeleteSubjectDetail(int id)
        {
            SubjectDetail subjectDetail = db.SubjectDetails.Find(id);
            if (subjectDetail == null)
            {
                return NotFound();
            }

            db.SubjectDetails.Remove(subjectDetail);
            db.SaveChanges();

            return Ok(subjectDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectDetailExists(int id)
        {
            return db.SubjectDetails.Count(e => e.ID == id) > 0;
        }
    }
}