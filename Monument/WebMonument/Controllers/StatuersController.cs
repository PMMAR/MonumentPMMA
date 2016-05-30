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
    public class StatuersController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/Statuers
        public IQueryable<Statuer> GetStatuer()
        {
            return db.Statuer;
        }

        // GET: api/Statuers/5
        [ResponseType(typeof(Statuer))]
        public IHttpActionResult GetStatuer(int id)
        {
            Statuer statuer = db.Statuer.Find(id);
            if (statuer == null)
            {
                return NotFound();
            }

            return Ok(statuer);
        }

        // PUT: api/Statuers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatuer(int id, Statuer statuer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statuer.Statue_id)
            {
                return BadRequest();
            }

            db.Entry(statuer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatuerExists(id))
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

        // POST: api/Statuers
        [ResponseType(typeof(Statuer))]
        public IHttpActionResult PostStatuer(Statuer statuer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Statuer.Add(statuer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statuer.Statue_id }, statuer);
        }

        // DELETE: api/Statuers/5
        [ResponseType(typeof(Statuer))]
        public IHttpActionResult DeleteStatuer(int id)
        {
            Statuer statuer = db.Statuer.Find(id);
            if (statuer == null)
            {
                return NotFound();
            }

            db.Statuer.Remove(statuer);
            db.SaveChanges();

            return Ok(statuer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatuerExists(int id)
        {
            return db.Statuer.Count(e => e.Statue_id == id) > 0;
        }
    }
}