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
    public class AdresseController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/Adresse
        public IQueryable<Adresse> GetAdresse()
        {
            return db.Adresse;
        }

        // GET: api/Adresse/5
        [ResponseType(typeof(Adresse))]
        public IHttpActionResult GetAdresse(int id)
        {
            Adresse adresse = db.Adresse.Find(id);
            if (adresse == null)
            {
                return NotFound();
            }

            return Ok(adresse);
        }

        // PUT: api/Adresse/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdresse(int id, Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adresse.PostNr)
            {
                return BadRequest();
            }

            db.Entry(adresse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresseExists(id))
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

        // POST: api/Adresse
        [ResponseType(typeof(Adresse))]
        public IHttpActionResult PostAdresse(Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adresse.Add(adresse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdresseExists(adresse.PostNr))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adresse.PostNr }, adresse);
        }

        // DELETE: api/Adresse/5
        [ResponseType(typeof(Adresse))]
        public IHttpActionResult DeleteAdresse(int id)
        {
            Adresse adresse = db.Adresse.Find(id);
            if (adresse == null)
            {
                return NotFound();
            }

            db.Adresse.Remove(adresse);
            db.SaveChanges();

            return Ok(adresse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdresseExists(int id)
        {
            return db.Adresse.Count(e => e.PostNr == id) > 0;
        }
    }
}