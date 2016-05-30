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
using WebMonument;

namespace WebMonument.Controllers
{
    public class SkadeTypersController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/SkadeTypers
        public IQueryable<SkadeTyper> GetSkadeTyper()
        {
            return db.SkadeTyper;
        }

        // GET: api/SkadeTypers/5
        [ResponseType(typeof(SkadeTyper))]
        public IHttpActionResult GetSkadeTyper(int id)
        {
            SkadeTyper skadeTyper = db.SkadeTyper.Find(id);
            if (skadeTyper == null)
            {
                return NotFound();
            }

            return Ok(skadeTyper);
        }

        // PUT: api/SkadeTypers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkadeTyper(int id, SkadeTyper skadeTyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skadeTyper.SkadeType_Id)
            {
                return BadRequest();
            }

            db.Entry(skadeTyper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkadeTyperExists(id))
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

        // POST: api/SkadeTypers
        [ResponseType(typeof(SkadeTyper))]
        public IHttpActionResult PostSkadeTyper(SkadeTyper skadeTyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SkadeTyper.Add(skadeTyper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = skadeTyper.SkadeType_Id }, skadeTyper);
        }

        // DELETE: api/SkadeTypers/5
        [ResponseType(typeof(SkadeTyper))]
        public IHttpActionResult DeleteSkadeTyper(int id)
        {
            SkadeTyper skadeTyper = db.SkadeTyper.Find(id);
            if (skadeTyper == null)
            {
                return NotFound();
            }

            db.SkadeTyper.Remove(skadeTyper);
            db.SaveChanges();

            return Ok(skadeTyper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkadeTyperExists(int id)
        {
            return db.SkadeTyper.Count(e => e.SkadeType_Id == id) > 0;
        }
    }
}