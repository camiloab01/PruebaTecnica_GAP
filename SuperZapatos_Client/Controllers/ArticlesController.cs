﻿using System;
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
        private Article_HttpHelper httpHelper = new Article_HttpHelper();

        // GET: Articles
        public async Task<ActionResult> Index()
        {
            return View(await httpHelper.GetArticlesAsync());
        }

        // GET: Articles
        public async Task<ActionResult> ByStore(int? storeId)
        {
            return View("Index", await httpHelper.GetArticlesByStoreAsync(storeId));
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
            return View();
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
                await httpHelper.CreateArticleAsync(articleModel);
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
            ArticleModel articleModel = await httpHelper.GetArticleAsync(id);
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
                await httpHelper.EditArticleAsync(articleModel);
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
            ArticleModel articleModel = await httpHelper.GetArticleAsync(id);
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
            await httpHelper.DeleteArticleAsync(id);
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
