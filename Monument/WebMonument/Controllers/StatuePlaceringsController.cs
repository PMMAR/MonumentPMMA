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
    public class StatuePlaceringsController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/StatuePlacerings
        public IQueryable<StatuePlacering> GetStatuePlacering()
        {
            return db.StatuePlacering;
        }

        // GET: api/StatuePlacerings/5
        [ResponseType(typeof(StatuePlacering))]
        public IHttpActionResult GetStatuePlacering(int id)
        {
            StatuePlacering statuePlacering = db.StatuePlacering.Find(id);
            if (statuePlacering == null)
            {
                return NotFound();
            }

            return Ok(statuePlacering);
        }

        // PUT: api/StatuePlacerings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatuePlacering(int id, StatuePlacering statuePlacering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statuePlacering.StatuePlacering_id)
            {
                return BadRequest();
            }

            db.Entry(statuePlacering).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatuePlaceringExists(id))
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

        // POST: api/StatuePlacerings
        [ResponseType(typeof(StatuePlacering))]
        public IHttpActionResult PostStatuePlacering(StatuePlacering statuePlacering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatuePlacering.Add(statuePlacering);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StatuePlaceringExists(statuePlacering.StatuePlacering_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = statuePlacering.StatuePlacering_id }, statuePlacering);
        }

        // DELETE: api/StatuePlacerings/5
        [ResponseType(typeof(StatuePlacering))]
        public IHttpActionResult DeleteStatuePlacering(int id)
        {
            StatuePlacering statuePlacering = db.StatuePlacering.Find(id);
            if (statuePlacering == null)
            {
                return NotFound();
            }

            db.StatuePlacering.Remove(statuePlacering);
            db.SaveChanges();

            return Ok(statuePlacering);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatuePlaceringExists(int id)
        {
            return db.StatuePlacering.Count(e => e.StatuePlacering_id == id) > 0;
        }
    }
}