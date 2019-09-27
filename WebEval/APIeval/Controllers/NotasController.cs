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
using APIeval.Models;

namespace APIeval.Controllers
{
    public class NotasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Notas
        public IQueryable<Nota> GetNotas()
        {
            return db.Notas;
        }

        // GET: api/Notas/5
        [ResponseType(typeof(Nota))]
        public IHttpActionResult GetNota(TypeSubject id)
        {
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return NotFound();
            }

            return Ok(nota);
        }

        // PUT: api/Notas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNota(TypeSubject id, Nota nota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nota.Subject)
            {
                return BadRequest();
            }

            db.Entry(nota).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaExists(id))
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

        // POST: api/Notas
        [ResponseType(typeof(Nota))]
        public IHttpActionResult PostNota(Nota nota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notas.Add(nota);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NotaExists(nota.Subject))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nota.Subject }, nota);
        }

        // DELETE: api/Notas/5
        [ResponseType(typeof(Nota))]
        public IHttpActionResult DeleteNota(TypeSubject id)
        {
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return NotFound();
            }

            db.Notas.Remove(nota);
            db.SaveChanges();

            return Ok(nota);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotaExists(TypeSubject id)
        {
            return db.Notas.Count(e => e.Subject == id) > 0;
        }
    }
}