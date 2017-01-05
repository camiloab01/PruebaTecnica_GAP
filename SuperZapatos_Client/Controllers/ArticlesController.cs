using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperZapatos_Client.Models;
using SuperZapatos_Client.Http_Helpers;

namespace SuperZapatos_Client.Controllers
{
    public class ArticlesController : Controller
    {
        private SuperZapatos_ClientContext db = new SuperZapatos_ClientContext();
        private Article_HttpHelper articleHttpHelper = new Article_HttpHelper();
        private Store_HttpHelper storeHttpHelper = new Store_HttpHelper();

        // GET: Articles
        public async Task<ActionResult> Index()
        {
            return View(await articleHttpHelper.GetArticlesAsync());
        }

        // GET: Articles
        public async Task<ActionResult> ByStore(int? storeId)
        {
            return View("Index", await articleHttpHelper.GetArticlesByStoreAsync(storeId));
        }

        // GET: Articles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleModel articleModel = await db.ArticleModels.FindAsync(id);
            if (articleModel == null)
            {
                return HttpNotFound();
            }
            return View(articleModel);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            var model = new ArticleStoreViewModel();

            model.Stores = storeHttpHelper.GetStoresAsync().Result.ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return View(model);
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Price,Total_in_shelf,Total_in_vault,Store_name")] ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                await articleHttpHelper.CreateArticleAsync(articleModel);
                return RedirectToAction("Index");
            }

            return View(articleModel);
        }

        // GET: Articles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleModel articleModel = await articleHttpHelper.GetArticleAsync(id);
            if (articleModel == null)
            {
                return HttpNotFound();
            }
            return View(articleModel);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Price,Total_in_shelf,Total_in_vault,Store")] ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                await articleHttpHelper.EditArticleAsync(articleModel);
                return RedirectToAction("Index");
            }
            return View(articleModel);
        }

        // GET: Articles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleModel articleModel = await articleHttpHelper.GetArticleAsync(id);
            if (articleModel == null)
            {
                return HttpNotFound();
            }
            return View(articleModel);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await articleHttpHelper.DeleteArticleAsync(id);
            return RedirectToAction("Index");
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
