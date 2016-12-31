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

namespace SuperZapatos.Controllers
{
    public class ArticlesController : ApiController
    {
        private SuperZapatos_APIContext db = new SuperZapatos_APIContext();

        // GET: services/Articles
        public IQueryable<ArticleDTO> GetArticles()
        {
            var articlesDTO = from a in db.Articles.Include(a => a.Store)
                              select new ArticleDTO()
                              {
                                  Id = a.Id,
                                  Name = a.Name,
                                  Description = a.Description,
                                  Price = a.Price,
                                  Total_in_shelf = a.Total_in_shelf,
                                  Total_in_vault = a.Total_in_vault,
                                  Store_name = a.Store.Name
                              };

            return articlesDTO;
        }

        // GET: services/Articles/5
        [ResponseType(typeof(ArticleDTO))]
        public async Task<IHttpActionResult> GetArticle(int id)
        {
            Article article = await db.Articles.Include(a => a.Store).FirstOrDefaultAsync(i => i.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            ArticleDTO articleDTO = new ArticleDTO()
            {
                Id = article.Id,
                Name = article.Name,
                Description = article.Description,
                Price = article.Price,
                Total_in_shelf = article.Total_in_shelf,
                Total_in_vault = article.Total_in_vault,
                Store_name = article.Store == null ? "Not defined" : article.Store.Name
            };

            return Ok(articleDTO);
        }

        // PUT: services/Articles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArticle(int id, Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.Id)
            {
                return BadRequest();
            }

            db.Entry(article).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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

        // POST: services/Articles
        [ResponseType(typeof(ArticleDTO))]
        public async Task<IHttpActionResult> PostArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Articles.Add(article);
            await db.SaveChangesAsync();

            ArticleDTO articleDTO = new ArticleDTO()
            {
                Id = article.Id,
                Name = article.Name,
                Description = article.Description,
                Price = article.Price,
                Total_in_shelf = article.Total_in_shelf,
                Total_in_vault = article.Total_in_vault,
                Store_name = article.Store == null ? "Not defined" : article.Store.Name
            };

            return CreatedAtRoute("DefaultApi", new { id = article.Id }, articleDTO);
        }

        // DELETE: services/Articles/5
        [ResponseType(typeof(ArticleDTO))]
        public async Task<IHttpActionResult> DeleteArticle(int id)
        {
            Article article = await db.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            db.Articles.Remove(article);
            await db.SaveChangesAsync();

            ArticleDTO articleDTO = new ArticleDTO()
            {
                Id = article.Id,
                Name = article.Name,
                Description = article.Description,
                Price = article.Price,
                Total_in_shelf = article.Total_in_shelf,
                Total_in_vault = article.Total_in_vault,
                Store_name = article.Store == null ? "Not defined" : article.Store.Name
            };

            return Ok(articleDTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticleExists(int id)
        {
            return db.Articles.Count(e => e.Id == id) > 0;
        }
    }
}