using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToyStoryApplication.Models;

namespace ToyStoryApplication.Controllers
{
    public class FranchisesController : Controller
    {
        private ToyDBEntities db = new ToyDBEntities();

        // GET: Franchises
        public ActionResult Index()
        {
            return View(db.Franchise.ToList());
        }

        // GET: Franchises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Franchise franchise = db.Franchise.Find(id);
            if (franchise == null)
            {
                return HttpNotFound();
            }
            return View(franchise);
        }

        // GET: Franchises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Franchises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Logo,Name,Origin,Type,FirstAppearance,CreatedBy,Count")] Franchise franchise)
        {
            if (ModelState.IsValid)
            {
                db.Franchise.Add(franchise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(franchise);
        }

        // GET: Franchises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Franchise franchise = db.Franchise.Find(id);
            if (franchise == null)
            {
                return HttpNotFound();
            }
            return View(franchise);
        }

        // POST: Franchises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Logo,Name,Origin,Type,FirstAppearance,CreatedBy,Count")] Franchise franchise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(franchise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(franchise);
        }

        // GET: Franchises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Franchise franchise = db.Franchise.Find(id);
            if (franchise == null)
            {
                return HttpNotFound();
            }
            return View(franchise);
        }

        // POST: Franchises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Franchise franchise = db.Franchise.Find(id);
            db.Franchise.Remove(franchise);
            db.SaveChanges();
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
