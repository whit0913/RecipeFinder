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
using RecipeFinder.Models;

namespace RecipeFinder.Controllers
{
    public class ActionsController : ApiController
    {
        private RecipeFinderEntities db = new RecipeFinderEntities();

        // GET: api/Actions
        public IQueryable<RecipeFinder.Models.Action> GetActions()
        {
            return db.Actions;
        }

        // GET: api/Actions/5
        [ResponseType(typeof(RecipeFinder.Models.Action))]
        public async Task<IHttpActionResult> GetAction(int id)
        {
            RecipeFinder.Models.Action action = await db.Actions.FindAsync(id);
            if (action == null)
            {
                return NotFound();
            }

            return Ok(action);
        }

        // PUT: api/Actions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAction(int id, RecipeFinder.Models.Action action)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != action.ActionId)
            {
                return BadRequest();
            }

            db.Entry(action).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionExists(id))
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

        // POST: api/Actions
        [ResponseType(typeof(RecipeFinder.Models.Action))]
        public async Task<IHttpActionResult> PostAction(RecipeFinder.Models.Action action)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Actions.Add(action);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActionExists(action.ActionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = action.ActionId }, action);
        }

        // DELETE: api/Actions/5
        [ResponseType(typeof(RecipeFinder.Models.Action))]
        public async Task<IHttpActionResult> DeleteAction(int id)
        {
            RecipeFinder.Models.Action action = await db.Actions.FindAsync(id);
            if (action == null)
            {
                return NotFound();
            }

            db.Actions.Remove(action);
            await db.SaveChangesAsync();

            return Ok(action);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActionExists(int id)
        {
            return db.Actions.Count(e => e.ActionId == id) > 0;
        }
    }
}