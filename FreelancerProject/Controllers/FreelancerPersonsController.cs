﻿using System;
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
    public class FreelancerPersonsController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();

        // GET: FreelancerPersons
        public ActionResult Index()
        {
            return View(db.FreelancerPerson.ToList());
        }

        // GET: FreelancerPersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerPerson freelancerPerson = db.FreelancerPerson.Find(id);
            if (freelancerPerson == null)
            {
                return HttpNotFound();
            }
            return View(freelancerPerson);
        }

        // GET: FreelancerPersons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FreelancerPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Firstname,Lastname,Birthday,Nationality,Address,ZipCode,City,Phonenumber,Email,LinkToLinkedIn,LinkToGithub")] FreelancerPerson freelancerPerson)
        {
            if (ModelState.IsValid)
            {
                db.FreelancerPerson.Add(freelancerPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(freelancerPerson);
        }

        // GET: FreelancerPersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerPerson freelancerPerson = db.FreelancerPerson.Find(id);
            if (freelancerPerson == null)
            {
                return HttpNotFound();
            }
            return View(freelancerPerson);
        }

        // POST: FreelancerPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,Birthday,Nationality,Address,ZipCode,City,Phonenumber,Email,LinkToLinkedIn,LinkToGithub")] FreelancerPerson freelancerPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freelancerPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(freelancerPerson);
        }

        // GET: FreelancerPersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerPerson freelancerPerson = db.FreelancerPerson.Find(id);
            if (freelancerPerson == null)
            {
                return HttpNotFound();
            }
            return View(freelancerPerson);
        }

        // POST: FreelancerPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FreelancerPerson freelancerPerson = db.FreelancerPerson.Find(id);
            db.FreelancerPerson.Remove(freelancerPerson);
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
