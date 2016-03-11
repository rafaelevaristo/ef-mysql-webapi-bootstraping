using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EFMySQLBoolStrap.Models;

namespace EFMySQLBoolStrap.Controllers.API
{
    public class EFRegTSTsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EFRegTSTs
        public IQueryable<EFRegTST> GetEFRegTSTs()
        {
            return db.EFRegTSTs;
        }

        // GET: api/EFRegTSTs/5
        [ResponseType(typeof(EFRegTST))]
        public async Task<IHttpActionResult> GetEFRegTST(int id)
        {
            EFRegTST eFRegTST = await db.EFRegTSTs.FindAsync(id);
            if (eFRegTST == null)
            {
                return NotFound();
            }

            return Ok(eFRegTST);
        }

        // PUT: api/EFRegTSTs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEFRegTST(int id, EFRegTST eFRegTST)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eFRegTST.Id)
            {
                return BadRequest();
            }

            db.Entry(eFRegTST).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EFRegTSTExists(id))
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

        // POST: api/EFRegTSTs
        [ResponseType(typeof(EFRegTST))]
        public async Task<IHttpActionResult> PostEFRegTST(EFRegTST eFRegTST)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EFRegTSTs.Add(eFRegTST);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eFRegTST.Id }, eFRegTST);
        }

        // DELETE: api/EFRegTSTs/5
        [ResponseType(typeof(EFRegTST))]
        public async Task<IHttpActionResult> DeleteEFRegTST(int id)
        {
            EFRegTST eFRegTST = await db.EFRegTSTs.FindAsync(id);
            if (eFRegTST == null)
            {
                return NotFound();
            }

            db.EFRegTSTs.Remove(eFRegTST);
            await db.SaveChangesAsync();

            return Ok(eFRegTST);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EFRegTSTExists(int id)
        {
            return db.EFRegTSTs.Count(e => e.Id == id) > 0;
        }
    }
}