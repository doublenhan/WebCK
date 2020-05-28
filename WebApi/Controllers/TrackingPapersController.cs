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
    public class TrackingPapersController : ApiController
    {
        private data db = new data();

        // GET: api/TrackingPapers
        public IQueryable<TrackingPaper> GetTrackingPapers()
        {
            return db.TrackingPapers;
        }

        // GET: api/TrackingPapers/5
        [ResponseType(typeof(TrackingPaper))]
        public IHttpActionResult GetTrackingPaper(int id)
        {
            TrackingPaper trackingPaper = db.TrackingPapers.Find(id);
            if (trackingPaper == null)
            {
                return NotFound();
            }

            return Ok(trackingPaper);
        }

        // PUT: api/TrackingPapers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrackingPaper(int id, TrackingPaper trackingPaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trackingPaper.ID)
            {
                return BadRequest();
            }

            db.Entry(trackingPaper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackingPaperExists(id))
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

        // POST: api/TrackingPapers
        [ResponseType(typeof(TrackingPaper))]
        public IHttpActionResult PostTrackingPaper(TrackingPaper trackingPaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrackingPapers.Add(trackingPaper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trackingPaper.ID }, trackingPaper);
        }

        // DELETE: api/TrackingPapers/5
        [ResponseType(typeof(TrackingPaper))]
        public IHttpActionResult DeleteTrackingPaper(int id)
        {
            TrackingPaper trackingPaper = db.TrackingPapers.Find(id);
            if (trackingPaper == null)
            {
                return NotFound();
            }

            db.TrackingPapers.Remove(trackingPaper);
            db.SaveChanges();

            return Ok(trackingPaper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackingPaperExists(int id)
        {
            return db.TrackingPapers.Count(e => e.ID == id) > 0;
        }
    }
}