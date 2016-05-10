﻿using System;
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
    public class BrugersController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/Brugers
        public IQueryable<Bruger> GetBruger()
        {
            return db.Bruger;
        }

        // GET: api/Brugers/5
        [ResponseType(typeof(Bruger))]
        public IHttpActionResult GetBruger(int id)
        {
            Bruger bruger = db.Bruger.Find(id);
            if (bruger == null)
            {
                return NotFound();
            }

            return Ok(bruger);
        }

        // PUT: api/Brugers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBruger(int id, Bruger bruger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bruger.Bruger_id)
            {
                return BadRequest();
            }

            db.Entry(bruger).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrugerExists(id))
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

        // POST: api/Brugers
        [ResponseType(typeof(Bruger))]
        public IHttpActionResult PostBruger(Bruger bruger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bruger.Add(bruger);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BrugerExists(bruger.Bruger_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bruger.Bruger_id }, bruger);
        }

        // DELETE: api/Brugers/5
        [ResponseType(typeof(Bruger))]
        public IHttpActionResult DeleteBruger(int id)
        {
            Bruger bruger = db.Bruger.Find(id);
            if (bruger == null)
            {
                return NotFound();
            }

            db.Bruger.Remove(bruger);
            db.SaveChanges();

            return Ok(bruger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrugerExists(int id)
        {
            return db.Bruger.Count(e => e.Bruger_id == id) > 0;
        }
    }
}