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
using SuperZapatos_API.Models;
using SuperZapatos_API.Models.DTO;

namespace SuperZapatos_API.Controllers
{
    public class StoresController : ApiController
    {
        private SuperZapatos_APIContext db = new SuperZapatos_APIContext();

        // GET: services/Stores
        public IQueryable<StoreDTO> GetStores()
        {
            var storesDTO = from s in db.Stores
                            select new StoreDTO()
                            {
                                Id = s.Id,
                                Name = s.Name,
                                Address = s.Address
                            };

            return storesDTO;
        }

        // GET: services/Stores/5
        [ResponseType(typeof(StoreDTO))]
        public async Task<IHttpActionResult> GetStore(int id)
        {
            Store store = await db.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            StoreDTO storeDTO = new StoreDTO()
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address
            };

            return Ok(storeDTO);
        }

        // PUT: services/Stores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStore(int id, Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store.Id)
            {
                return BadRequest();
            }

            db.Entry(store).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
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

        // POST: services/Stores
        [ResponseType(typeof(StoreDTO))]
        public async Task<IHttpActionResult> PostStore(Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stores.Add(store);
            await db.SaveChangesAsync();

            StoreDTO storeDTO = new StoreDTO()
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address
            };

            return CreatedAtRoute("DefaultApi", new { id = store.Id }, storeDTO);
        }

        // DELETE: services/Stores/5
        [ResponseType(typeof(StoreDTO))]
        public async Task<IHttpActionResult> DeleteStore(int id)
        {
            Store store = await db.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            db.Stores.Remove(store);
            await db.SaveChangesAsync();

            StoreDTO storeDTO = new StoreDTO()
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address
            };

            return Ok(storeDTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreExists(int id)
        {
            return db.Stores.Count(e => e.Id == id) > 0;
        }
    }
}