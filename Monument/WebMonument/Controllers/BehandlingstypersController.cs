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
    public class BehandlingstypersController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/Behandlingstypers
        public IQueryable<Behandlingstyper> GetBehandlingstyper()
        {
            return db.Behandlingstyper;
        }

        // GET: api/Behandlingstypers/5
        [ResponseType(typeof(Behandlingstyper))]
        public IHttpActionResult GetBehandlingstyper(int id)
        {
            Behandlingstyper behandlingstyper = db.Behandlingstyper.Find(id);
            if (behandlingstyper == null)
            {
                return NotFound();
            }

            return Ok(behandlingstyper);
        }

        // PUT: api/Behandlingstypers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBehandlingstyper(int id, Behandlingstyper behandlingstyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != behandlingstyper.Behandlingstype_id)
            {
                return BadRequest();
            }

            db.Entry(behandlingstyper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BehandlingstyperExists(id))
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

        // POST: api/Behandlingstypers
        [ResponseType(typeof(Behandlingstyper))]
        public IHttpActionResult PostBehandlingstyper(Behandlingstyper behandlingstyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Behandlingstyper.Add(behandlingstyper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = behandlingstyper.Behandlingstype_id }, behandlingstyper);
        }

        // DELETE: api/Behandlingstypers/5
        [ResponseType(typeof(Behandlingstyper))]
        public IHttpActionResult DeleteBehandlingstyper(int id)
        {
            Behandlingstyper behandlingstyper = db.Behandlingstyper.Find(id);
            if (behandlingstyper == null)
            {
                return NotFound();
            }

            db.Behandlingstyper.Remove(behandlingstyper);
            db.SaveChanges();

            return Ok(behandlingstyper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BehandlingstyperExists(int id)
        {
            return db.Behandlingstyper.Count(e => e.Behandlingstype_id == id) > 0;
        }
    }
}