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
    public class SkadersController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/Skaders
        public IQueryable<Skader> GetSkader()
        {
            return db.Skader;
        }

        // GET: api/Skaders/5
        [ResponseType(typeof(Skader))]
        public IHttpActionResult GetSkader(int id)
        {
            Skader skader = db.Skader.Find(id);
            if (skader == null)
            {
                return NotFound();
            }

            return Ok(skader);
        }

        // PUT: api/Skaders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkader(int id, Skader skader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skader.Skade_id)
            {
                return BadRequest();
            }

            db.Entry(skader).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkaderExists(id))
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

        // POST: api/Skaders
        [ResponseType(typeof(Skader))]
        public IHttpActionResult PostSkader(Skader skader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Skader.Add(skader);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SkaderExists(skader.Skade_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = skader.Skade_id }, skader);
        }

        // DELETE: api/Skaders/5
        [ResponseType(typeof(Skader))]
        public IHttpActionResult DeleteSkader(int id)
        {
            Skader skader = db.Skader.Find(id);
            if (skader == null)
            {
                return NotFound();
            }

            db.Skader.Remove(skader);
            db.SaveChanges();

            return Ok(skader);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkaderExists(int id)
        {
            return db.Skader.Count(e => e.Skade_id == id) > 0;
        }
    }
}