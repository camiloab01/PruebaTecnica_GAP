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
    public class StoresController : Controller
    {
        private SuperZapatos_ClientContext db = new SuperZapatos_ClientContext();
        private Store_HttpHelper httpHelper = new Store_HttpHelper();

        // GET: Stores
        public async Task<ActionResult> Index()
        {
            return View(await httpHelper.GetStoresAsync());
        }

        // GET: Stores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = await db.StoreModels.FindAsync(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Address")] StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                db.StoreModels.Add(storeModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(storeModel);
        }

        // GET: Stores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = await db.StoreModels.FindAsync(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Address")] StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(storeModel);
        }

        // GET: Stores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = await db.StoreModels.FindAsync(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StoreModel storeModel = await db.StoreModels.FindAsync(id);
            db.StoreModels.Remove(storeModel);
            await db.SaveChangesAsync();
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
