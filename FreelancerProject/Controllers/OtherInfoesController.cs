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
    public class OtherInfoesController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();

        // GET: OtherInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherInfo otherInfo = db.OtherInfo.Find(id);
            if (otherInfo == null)
            {
                return HttpNotFound();
            }
            return View(otherInfo);
        }

        // GET: OtherInfoes/Create
        public ActionResult Create(int? freelancerId)
        {
            if(freelancerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var otherinfo = new OtherInfo()
            {
                FreelancerId = Convert.ToInt32(freelancerId)
            };

            return View(otherinfo);
        }

        // POST: OtherInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FreelancerId,DriversLicence,Languages,CoreCompetences,ProfileMessage")] OtherInfo otherInfo)
        {
            if (ModelState.IsValid)
            {
                db.OtherInfo.Add(otherInfo);
                db.SaveChanges();
                return RedirectToAction("Index", "ProfileFreelancer", new { freelancerId = otherInfo.FreelancerId });
            }

            return View(otherInfo);
        }

        // GET: OtherInfoes/Edit/5
        public ActionResult Edit(int? freelancerId)
        {
            if (freelancerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherInfo otherInfo = db.OtherInfo.Find(freelancerId);
            if (otherInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.FreelancerId = new SelectList(db.FreelancerPerson, "Id", "Firstname", otherInfo.FreelancerId);
            return View(otherInfo);
        }

        // POST: OtherInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FreelancerId,DriversLicence,Languages,CoreCompetences,ProfileMessage")] OtherInfo otherInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otherInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "FreelancerCV", new { otherInfo.FreelancerId });
            }
            ViewBag.FreelancerId = new SelectList(db.FreelancerPerson, "Id", "Firstname", otherInfo.FreelancerId);
            return View(otherInfo);
        }

        // GET: OtherInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherInfo otherInfo = db.OtherInfo.Find(id);
            if (otherInfo == null)
            {
                return HttpNotFound();
            }
            return View(otherInfo);
        }

        // POST: OtherInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OtherInfo otherInfo = db.OtherInfo.Find(id);
            db.OtherInfo.Remove(otherInfo);
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
