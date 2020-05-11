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
    public class SlidesController : ApiController
    {
        private ServerDBContext db = new ServerDBContext();

        // GET: api/Slides
        public IQueryable<Slide> GetSlides()
        {
            return db.Slides;
        }

        // GET: api/Slides/5
        [ResponseType(typeof(Slide))]
        public IHttpActionResult GetSlide(int id)
        {
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return NotFound();
            }

            return Ok(slide);
        }

        // PUT: api/Slides/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSlide(int id, Slide slide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != slide.ID)
            {
                return BadRequest();
            }

            db.Entry(slide).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlideExists(id))
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

        // POST: api/Slides
        [ResponseType(typeof(Slide))]
        public IHttpActionResult PostSlide(Slide slide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Slides.Add(slide);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = slide.ID }, slide);
        }

        // DELETE: api/Slides/5
        [ResponseType(typeof(Slide))]
        public IHttpActionResult DeleteSlide(int id)
        {
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return NotFound();
            }

            db.Slides.Remove(slide);
            db.SaveChanges();

            return Ok(slide);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SlideExists(int id)
        {
            return db.Slides.Count(e => e.ID == id) > 0;
        }
    }
}