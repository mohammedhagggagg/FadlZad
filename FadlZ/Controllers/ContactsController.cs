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
using FadlZ.Models;

namespace FadlZ.Controllers
{
    public class ContactsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Contacts
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public List<Contact> GetContacts()
        {
            try
            {
                return db.Contacts.ToList();
            }
            catch
            {
                return null;
            }
            
        }

        

    
        // POST: api/Contacts
        [AllowAnonymous]
        [HttpPost]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                  db.Contacts.Add(contact);
                  db.SaveChanges();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok("Added Succefully");
        }

        // DELETE: api/Contacts/5
        [Authorize]
        [HttpDelete]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            try
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}