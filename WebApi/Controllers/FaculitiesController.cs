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
    public class FaculitiesController : ApiController
    {
        private data db = new data();

        // GET: api/Faculities
        public IQueryable<Faculity> GetFaculities()
        {
            return db.Faculities;
        }

        // GET: api/Faculities/5
        [ResponseType(typeof(Faculity))]
        public IHttpActionResult GetFaculity(int id)
        {
            Faculity faculity = db.Faculities.Find(id);
            if (faculity == null)
            {
                return NotFound();
            }

            return Ok(faculity);
        }

        // PUT: api/Faculities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFaculity(int id, Faculity faculity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faculity.ID)
            {
                return BadRequest();
            }

            db.Entry(faculity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaculityExists(id))
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

        // POST: api/Faculities
        [ResponseType(typeof(Faculity))]
        public IHttpActionResult PostFaculity(Faculity faculity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faculities.Add(faculity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = faculity.ID }, faculity);
        }

        // DELETE: api/Faculities/5
        [ResponseType(typeof(Faculity))]
        public IHttpActionResult DeleteFaculity(int id)
        {
            Faculity faculity = db.Faculities.Find(id);
            if (faculity == null)
            {
                return NotFound();
            }

            db.Faculities.Remove(faculity);
            db.SaveChanges();

            return Ok(faculity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FaculityExists(int id)
        {
            return db.Faculities.Count(e => e.ID == id) > 0;
        }
    }
}