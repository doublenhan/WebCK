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
    public class FanpagesController : ApiController
    {
        private ServerDBContext db = new ServerDBContext();

        // GET: api/Fanpages
        public IQueryable<Fanpage> GetFanpages()
        {
            return db.Fanpages;
        }

        // GET: api/Fanpages/5
        [ResponseType(typeof(Fanpage))]
        public IHttpActionResult GetFanpage(int id)
        {
            Fanpage fanpage = db.Fanpages.Find(id);
            if (fanpage == null)
            {
                return NotFound();
            }

            return Ok(fanpage);
        }

        // PUT: api/Fanpages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFanpage(int id, Fanpage fanpage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fanpage.ID)
            {
                return BadRequest();
            }

            db.Entry(fanpage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FanpageExists(id))
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

        // POST: api/Fanpages
        [ResponseType(typeof(Fanpage))]
        public IHttpActionResult PostFanpage(Fanpage fanpage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fanpages.Add(fanpage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fanpage.ID }, fanpage);
        }

        // DELETE: api/Fanpages/5
        [ResponseType(typeof(Fanpage))]
        public IHttpActionResult DeleteFanpage(int id)
        {
            Fanpage fanpage = db.Fanpages.Find(id);
            if (fanpage == null)
            {
                return NotFound();
            }

            db.Fanpages.Remove(fanpage);
            db.SaveChanges();

            return Ok(fanpage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FanpageExists(int id)
        {
            return db.Fanpages.Count(e => e.ID == id) > 0;
        }
    }
}