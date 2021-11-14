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
    public class appointmentsController : ApiController
    {
        private namdhp db = new namdhp();

        // GET: api/appointments
        public IQueryable<appointment> Getappointments()
        {
            return db.appointments;
        }

        // GET: api/appointments/5
        [ResponseType(typeof(appointment))]
        public IHttpActionResult Getappointment(int id)
        {
            appointment appointment = db.appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        // PUT: api/appointments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putappointment(int id, appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.id)
            {
                return BadRequest();
            }

            db.Entry(appointment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!appointmentExists(id))
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

        // POST: api/appointments
        [ResponseType(typeof(appointment))]
        public IHttpActionResult Postappointment(appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.appointments.Add(appointment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (appointmentExists(appointment.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = appointment.id }, appointment);
        }

        // DELETE: api/appointments/5
        [ResponseType(typeof(appointment))]
        public IHttpActionResult Deleteappointment(int id)
        {
            appointment appointment = db.appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            db.appointments.Remove(appointment);
            db.SaveChanges();

            return Ok(appointment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool appointmentExists(int id)
        {
            return db.appointments.Count(e => e.id == id) > 0;
        }
    }
}