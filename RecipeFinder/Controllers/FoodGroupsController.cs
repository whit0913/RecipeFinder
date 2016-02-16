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
    public class FoodGroupsController : ApiController
    {
        private RecipeFinderEntities db = new RecipeFinderEntities();

        // GET: api/FoodGroups
        public IQueryable<FoodGroup> GetFoodGroups()
        {
            return db.FoodGroups;
        }

        // GET: api/FoodGroups/5
        [ResponseType(typeof(FoodGroup))]
        public async Task<IHttpActionResult> GetFoodGroup(int id)
        {
            FoodGroup foodGroup = await db.FoodGroups.FindAsync(id);
            if (foodGroup == null)
            {
                return NotFound();
            }

            return Ok(foodGroup);
        }

        // PUT: api/FoodGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFoodGroup(int id, FoodGroup foodGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foodGroup.FoodGroupId)
            {
                return BadRequest();
            }

            db.Entry(foodGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodGroupExists(id))
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

        // POST: api/FoodGroups
        [ResponseType(typeof(FoodGroup))]
        public async Task<IHttpActionResult> PostFoodGroup(FoodGroup foodGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FoodGroups.Add(foodGroup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FoodGroupExists(foodGroup.FoodGroupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = foodGroup.FoodGroupId }, foodGroup);
        }

        // DELETE: api/FoodGroups/5
        [ResponseType(typeof(FoodGroup))]
        public async Task<IHttpActionResult> DeleteFoodGroup(int id)
        {
            FoodGroup foodGroup = await db.FoodGroups.FindAsync(id);
            if (foodGroup == null)
            {
                return NotFound();
            }

            db.FoodGroups.Remove(foodGroup);
            await db.SaveChangesAsync();

            return Ok(foodGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodGroupExists(int id)
        {
            return db.FoodGroups.Count(e => e.FoodGroupId == id) > 0;
        }
    }
}