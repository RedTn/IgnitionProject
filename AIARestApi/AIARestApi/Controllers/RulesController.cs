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
    public class RulesController : ApiController
    {
        private AIADbEntities db = new AIADbEntities();

        // GET: api/Rules
        public IQueryable<Rule> GetRules()
        {
            return db.Rules;
        }

        // GET: api/Rules/5
        [ResponseType(typeof(Rule))]
        public IHttpActionResult GetRule(Guid id)
        {
            Rule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return NotFound();
            }

            return Ok(rule);
        }

        // PUT: api/Rules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRule(Guid id, Rule rule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rule.Id)
            {
                return BadRequest();
            }

            db.Entry(rule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuleExists(id))
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

        // POST: api/Rules
        [ResponseType(typeof(Rule))]
        public IHttpActionResult PostRule(Rule rule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rules.Add(rule);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RuleExists(rule.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rule.Id }, rule);
        }

        // DELETE: api/Rules/5
        [ResponseType(typeof(Rule))]
        public IHttpActionResult DeleteRule(Guid id)
        {
            Rule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return NotFound();
            }

            db.Rules.Remove(rule);
            db.SaveChanges();

            return Ok(rule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RuleExists(Guid id)
        {
            return db.Rules.Count(e => e.Id == id) > 0;
        }
    }
}