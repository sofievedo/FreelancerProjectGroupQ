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
    public class WorksController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();


        // GET: Works/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Work.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // GET: Works/Create
        public ActionResult Create(int? freelancerId)
        {
            ViewBag.FreelancerId = freelancerId;
            return View();
        }

        // POST: Works/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FreelancerId,Role,Company,StartDate,EndDate,WorkDescription")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Work.Add(work);
                db.SaveChanges();
                return RedirectToAction("Index", "FreelancerCV", new { work.FreelancerId });
            }

            ViewBag.FreelancerId = new SelectList(db.FreelancerPerson, "Id", "Firstname", work.FreelancerId);
            return View(work);
        }

        // GET: Works/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Work.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            ViewBag.FreelancerId = work.FreelancerId;
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FreelancerId,Role,Company,StartDate,EndDate,WorkDescription")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "FreelancerCV", new { work.FreelancerId });
            }
            ViewBag.FreelancerId =  work.FreelancerId;
            return View(work);
        }

        // GET: Works/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Work.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work work = db.Work.Find(id);
            db.Work.Remove(work);
            db.SaveChanges();
            return RedirectToAction("Index", "FreelancerCV", new { work.FreelancerId });
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
