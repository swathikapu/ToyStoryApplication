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

        public ActionResult _Indexpartial(int? id)
        {
            Franchise franchise = db.Franchise.Single(m => m.Id == id);
            return PartialView(franchise);
        }

        [HttpPost]
        public ActionResult Like(int? id)
        {
            Franchise franchise = db.Franchise.Single(m => m.Id == id);
            if (franchise == null)
                return HttpNotFound();
            int currentLikes = franchise.Count;
            franchise.Count = currentLikes + 1;
            db.SaveChanges();
            return PartialView("_Indexpartial", franchise);
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
        public ActionResult Create(Franchise franchise)
        {
            TryUpdateModel(franchise);
            if (ModelState.IsValid)
            {
                string imagePath = "~/Content/Images/" + franchise.ImageFile.FileName;
                franchise.Logo = imagePath;
                franchise.ImageFile.SaveAs(Server.MapPath(imagePath));
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
        public ActionResult Edit(Franchise franchise)
        {
            Franchise franchiseInDb = db.Franchise.Single(x => x.Id == franchise.Id);
            if (franchise.Logo != null)
                franchiseInDb.Logo = franchise.Logo;
            franchiseInDb.Name = franchise.Name;
            franchiseInDb.Origin = franchise.Origin;
            franchiseInDb.Type = franchise.Type;
            franchiseInDb.FirstAppearance = franchise.FirstAppearance;
            franchiseInDb.CreatedBy = franchise.CreatedBy;
            TryUpdateModel(franchiseInDb);
            if (ModelState.IsValid)
            {
                db.Entry(franchiseInDb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(franchiseInDb);
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
