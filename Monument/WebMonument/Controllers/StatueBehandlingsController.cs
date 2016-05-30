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
    public class StatueBehandlingsController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/StatueBehandlings
        public IQueryable<StatueBehandling> GetStatueBehandling()
        {
            return db.StatueBehandling;
        }

        // GET: api/StatueBehandlings/5
        [ResponseType(typeof(StatueBehandling))]
        public IHttpActionResult GetStatueBehandling(int id)
        {
            StatueBehandling statueBehandling = db.StatueBehandling.Find(id);
            if (statueBehandling == null)
            {
                return NotFound();
            }

            return Ok(statueBehandling);
        }

        // PUT: api/StatueBehandlings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatueBehandling(int id, StatueBehandling statueBehandling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statueBehandling.StatueBehandling_id)
            {
                return BadRequest();
            }

            db.Entry(statueBehandling).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatueBehandlingExists(id))
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

        // POST: api/StatueBehandlings
        [ResponseType(typeof(StatueBehandling))]
        public IHttpActionResult PostStatueBehandling(StatueBehandling statueBehandling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatueBehandling.Add(statueBehandling);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statueBehandling.StatueBehandling_id }, statueBehandling);
        }

        // DELETE: api/StatueBehandlings/5
        [ResponseType(typeof(StatueBehandling))]
        public IHttpActionResult DeleteStatueBehandling(int id)
        {
            StatueBehandling statueBehandling = db.StatueBehandling.Find(id);
            if (statueBehandling == null)
            {
                return NotFound();
            }

            db.StatueBehandling.Remove(statueBehandling);
            db.SaveChanges();

            return Ok(statueBehandling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatueBehandlingExists(int id)
        {
            return db.StatueBehandling.Count(e => e.StatueBehandling_id == id) > 0;
        }
    }
}