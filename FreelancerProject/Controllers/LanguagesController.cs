using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FreelancerProject.Models;

namespace FreelancerProject.Controllers
{
    public class LanguagesController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();

        // GET: Languages
        public ActionResult Edit(int? freelancerId)
        {
            if(freelancerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Languages languages = db.Languages.Find(freelancerId);

            if (languages == null)
            {
                return HttpNotFound();
            }
            return View(languages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Language")] Education education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "FreelancerCV", new { education.FreelancerId });
            }
            ViewBag.FreelancerId = education.FreelancerId;
            return View(education);
        }

    }
}