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
using APIproceso.Models;

namespace APIproceso.Controllers
{
    public class ProcesoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Procesoes
        public IQueryable<Proceso> GetProcesoes()
        {
            return db.Procesoes;
        }

        // GET: api/Procesoes/5
        [ResponseType(typeof(Proceso))]
        public IHttpActionResult GetProceso(int id)
        {
            Proceso proceso = db.Procesoes.Find(id);
            if (proceso == null)
            {
                return NotFound();
            }

            return Ok(proceso);
        }

        // PUT: api/Procesoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProceso(int id, Proceso proceso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proceso.ProcesoId)
            {
                return BadRequest();
            }

            db.Entry(proceso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcesoExists(id))
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

        // POST: api/Procesoes
        [ResponseType(typeof(Proceso))]
        public IHttpActionResult PostProceso(Proceso proceso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Procesoes.Add(proceso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proceso.ProcesoId }, proceso);
        }

        // DELETE: api/Procesoes/5
        [ResponseType(typeof(Proceso))]
        public IHttpActionResult DeleteProceso(int id)
        {
            Proceso proceso = db.Procesoes.Find(id);
            if (proceso == null)
            {
                return NotFound();
            }

            db.Procesoes.Remove(proceso);
            db.SaveChanges();

            return Ok(proceso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProcesoExists(int id)
        {
            return db.Procesoes.Count(e => e.ProcesoId == id) > 0;
        }
    }
}