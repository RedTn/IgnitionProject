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
using AIARestApi;

namespace AIARestApi.Controllers
{
    public class AIAUsersController : ApiController
    {
        private AIADbEntities db = new AIADbEntities();

        // GET: api/AIAUsers
        public IQueryable<AIAUser> GetAIAUsers()
        {
            return db.AIAUsers;
        }

        // GET: api/AIAUsers/5
        [ResponseType(typeof(AIAUser))]
        public IHttpActionResult GetAIAUser(int id)
        {
            AIAUser aIAUser = db.AIAUsers.Find(id);
            if (aIAUser == null)
            {
                return NotFound();
            }

            return Ok(aIAUser);
        }

        // PUT: api/AIAUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAIAUser(int id, AIAUser aIAUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aIAUser.Id)
            {
                return BadRequest();
            }

            db.Entry(aIAUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AIAUserExists(id))
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

        // POST: api/AIAUsers
        [ResponseType(typeof(AIAUser))]
        public IHttpActionResult PostAIAUser(AIAUser aIAUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AIAUsers.Add(aIAUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aIAUser.Id }, aIAUser);
        }

        // DELETE: api/AIAUsers/5
        [ResponseType(typeof(AIAUser))]
        public IHttpActionResult DeleteAIAUser(int id)
        {
            AIAUser aIAUser = db.AIAUsers.Find(id);
            if (aIAUser == null)
            {
                return NotFound();
            }

            db.AIAUsers.Remove(aIAUser);
            db.SaveChanges();

            return Ok(aIAUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AIAUserExists(int id)
        {
            return db.AIAUsers.Count(e => e.Id == id) > 0;
        }
    }
}