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
    public class T_SubjectController : ApiController
    {
        private data db = new data();

        // GET: api/T_Subject
        public IQueryable<T_Subject> GetT_Subject()
        {
            return db.T_Subject;
        }

        // GET: api/T_Subject/5
        [ResponseType(typeof(T_Subject))]
        public IHttpActionResult GetT_Subject(int id)
        {
            T_Subject t_Subject = db.T_Subject.Find(id);
            if (t_Subject == null)
            {
                return NotFound();
            }

            return Ok(t_Subject);
        }

        // PUT: api/T_Subject/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutT_Subject(int id, T_Subject t_Subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_Subject.ID)
            {
                return BadRequest();
            }

            db.Entry(t_Subject).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_SubjectExists(id))
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

        // POST: api/T_Subject
        [ResponseType(typeof(T_Subject))]
        public IHttpActionResult PostT_Subject(T_Subject t_Subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_Subject.Add(t_Subject);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_Subject.ID }, t_Subject);
        }

        // DELETE: api/T_Subject/5
        [ResponseType(typeof(T_Subject))]
        public IHttpActionResult DeleteT_Subject(int id)
        {
            T_Subject t_Subject = db.T_Subject.Find(id);
            if (t_Subject == null)
            {
                return NotFound();
            }

            db.T_Subject.Remove(t_Subject);
            db.SaveChanges();

            return Ok(t_Subject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_SubjectExists(int id)
        {
            return db.T_Subject.Count(e => e.ID == id) > 0;
        }
    }
}