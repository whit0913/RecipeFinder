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
    public class RecipeProcessesController : ApiController
    {
        private RecipeFinderEntities db = new RecipeFinderEntities();

        // GET: api/RecipeProcesses
        public IQueryable<RecipeProcess> GetRecipeProcesses()
        {
            return db.RecipeProcesses;
        }

        // GET: api/RecipeProcesses/5
        [ResponseType(typeof(RecipeProcess))]
        public async Task<IHttpActionResult> GetRecipeProcess(int id)
        {
            RecipeProcess recipeProcess = await db.RecipeProcesses.FindAsync(id);
            if (recipeProcess == null)
            {
                return NotFound();
            }

            return Ok(recipeProcess);
        }

        // PUT: api/RecipeProcesses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecipeProcess(int id, RecipeProcess recipeProcess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeProcess.RecipeId)
            {
                return BadRequest();
            }

            db.Entry(recipeProcess).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeProcessExists(id))
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

        // POST: api/RecipeProcesses
        [ResponseType(typeof(RecipeProcess))]
        public async Task<IHttpActionResult> PostRecipeProcess(RecipeProcess recipeProcess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecipeProcesses.Add(recipeProcess);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecipeProcessExists(recipeProcess.RecipeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = recipeProcess.RecipeId }, recipeProcess);
        }

        // DELETE: api/RecipeProcesses/5
        [ResponseType(typeof(RecipeProcess))]
        public async Task<IHttpActionResult> DeleteRecipeProcess(int id)
        {
            RecipeProcess recipeProcess = await db.RecipeProcesses.FindAsync(id);
            if (recipeProcess == null)
            {
                return NotFound();
            }

            db.RecipeProcesses.Remove(recipeProcess);
            await db.SaveChangesAsync();

            return Ok(recipeProcess);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeProcessExists(int id)
        {
            return db.RecipeProcesses.Count(e => e.RecipeId == id) > 0;
        }
    }
}