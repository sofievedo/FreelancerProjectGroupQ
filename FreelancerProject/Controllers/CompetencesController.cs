using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FreelancerProject.Models;

namespace FreelancerProject.Controllers
{
    public class CompetencesController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();

        // GET: Competences
        public ActionResult Index()
        {
            var competence = db.Competence.Include(c => c.Role);
            return View(competence.ToList());
        }

        // GET: Competences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competence competence = db.Competence.Find(id);
            if (competence == null)
            {
                return HttpNotFound();
            }
            return View(competence);
        }

        // GET: Competences/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Role, "Id", "RoleName");
            return View();
        }

        // POST: Competences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleId,CompetenceName")] Competence competence)
        {
            if (ModelState.IsValid)
            {
                db.Competence.Add(competence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Role, "Id", "RoleName", competence.RoleId);
            return View(competence);
        }

        // GET: Competences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competence competence = db.Competence.Find(id);
            if (competence == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Role, "Id", "RoleName", competence.RoleId);
            return View(competence);
        }

        // POST: Competences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,CompetenceName")] Competence competence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Role, "Id", "RoleName", competence.RoleId);
            return View(competence);
        }

        // GET: Competences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competence competence = db.Competence.Find(id);
            if (competence == null)
            {
                return HttpNotFound();
            }
            return View(competence);
        }

        // POST: Competences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competence competence = db.Competence.Find(id);
            db.Competence.Remove(competence);
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
