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
    public class EducationsController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();

        // GET: Educations
        public ActionResult Index()
        {
            var education = db.Education.Include(e => e.FreelancerPerson);
            return View(education.ToList());
        }

        // GET: Educations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Education.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // GET: Educations/Create
        public ActionResult Create(int? freelancerId)
        {
            //TODO: lägg till vad som händer om int är null. 
            ViewBag.FreelancerId = freelancerId;
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FreelancerId,School,Degree,Subject,StartDate,EndDate")] Education education)
        {
            if (ModelState.IsValid)
            {
                //TODO: Lägg till logik så slutdatum ej kan vara innan slutdatum
                db.Education.Add(education);
                db.SaveChanges();
                return RedirectToAction("Index", "FreelancerCV", new { education.FreelancerId });
            }

            ViewBag.FreelancerId = new SelectList(db.FreelancerPerson, "Id", "Firstname", education.FreelancerId);
            return View(education);
        }

        // GET: Educations/Edit/5
        public ActionResult Edit(int? freelancerId)
        {
            if (freelancerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Education.Find(freelancerId);
            if (education == null)
            {
                return HttpNotFound();
            }
            ViewBag.FreelancerId = freelancerId;
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FreelancerId,School,Degree,Subject,StartDate,EndDate")] Education education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FreelancerId = new SelectList(db.FreelancerPerson, "Id", "Firstname", education.FreelancerId);
            return View(education);
        }

        // GET: Educations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Education.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Education education = db.Education.Find(id);
            db.Education.Remove(education);
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
