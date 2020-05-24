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
    public class SildesController : ApiController
    {
        private data db = new data();

        // GET: api/Sildes
        public IQueryable<Silde> GetSildes()
        {
            return db.Sildes;
        }

        // GET: api/Sildes/5
        [ResponseType(typeof(Silde))]
        public IHttpActionResult GetSilde(int id)
        {
            Silde silde = db.Sildes.Find(id);
            if (silde == null)
            {
                return NotFound();
            }

            return Ok(silde);
        }

        // PUT: api/Sildes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSilde(int id, Silde silde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != silde.ID_Silde)
            {
                return BadRequest();
            }

            db.Entry(silde).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SildeExists(id))
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

        // POST: api/Sildes
        [ResponseType(typeof(Silde))]
        public IHttpActionResult PostSilde(Silde silde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sildes.Add(silde);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = silde.ID_Silde }, silde);
        }

        // DELETE: api/Sildes/5
        [ResponseType(typeof(Silde))]
        public IHttpActionResult DeleteSilde(int id)
        {
            Silde silde = db.Sildes.Find(id);
            if (silde == null)
            {
                return NotFound();
            }

            db.Sildes.Remove(silde);
            db.SaveChanges();

            return Ok(silde);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SildeExists(int id)
        {
            return db.Sildes.Count(e => e.ID_Silde == id) > 0;
        }
    }
}