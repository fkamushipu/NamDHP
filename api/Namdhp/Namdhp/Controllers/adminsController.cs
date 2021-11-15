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
using Namdhp.Models;

namespace Namdhp.Controllers
{
    public class adminsController : ApiController
    {
        private namdhp db = new namdhp();

        [Route("authenticate_admin")]
        public IHttpActionResult auth(string username, string password)
        {
            var user_name = db.admins.Where(r => r.username == username).FirstOrDefault();
            var pass_word = db.admins.Where(p => p.password == password).FirstOrDefault();


            if (user_name != null && pass_word != null)
            {
                return Ok(pass_word);
            }

            return StatusCode(HttpStatusCode.NoContent);

        }

        // GET: api/admins
        public IQueryable<admin> Getadmins()
        {
            return db.admins;
        }

        // GET: api/admins/5
        [ResponseType(typeof(admin))]
        public IHttpActionResult Getadmin(int id)
        {
            admin admin = db.admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/admins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putadmin(int id, admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.id)
            {
                return BadRequest();
            }

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adminExists(id))
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

        // POST: api/admins
        [ResponseType(typeof(admin))]
        public IHttpActionResult Postadmin(admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.admins.Add(admin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (adminExists(admin.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = admin.id }, admin);
        }

        // DELETE: api/admins/5
        [ResponseType(typeof(admin))]
        public IHttpActionResult Deleteadmin(int id)
        {
            admin admin = db.admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            db.admins.Remove(admin);
            db.SaveChanges();

            return Ok(admin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool adminExists(int id)
        {
            return db.admins.Count(e => e.id == id) > 0;
        }
    }
}