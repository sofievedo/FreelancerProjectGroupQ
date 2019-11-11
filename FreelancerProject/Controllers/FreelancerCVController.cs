using FreelancerProject.Controllers;
using FreelancerProject.Models;
using FreelancerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FreelancerProject.Controllers
{
    public class FreelancerCVController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();

        // GET: FreelancerCV
        public ActionResult Index(int? id = 1)
        {
            var freelancer = new FreelancerCVViewmodel(id);

            return View(freelancer);
        }

        [HttpGet]
        public ActionResult CustomerView(int? id = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var freelancerId = 1; //TODO: Ta bort hårdkodning
            var viewModel = new FreelancerCVViewmodel(id, freelancerId);

            return View(viewModel);
        }

        public ActionResult SaveFreelancer(int id)
        {
            var customer = db.Customer.Find(1); //TODO: Ta bort hårdkodning, skicka in som variabel
            var freelancer = db.FreelancerPerson.Find(id);

            if (!customer.FreelancerPerson.Contains(freelancer))
            {
        
                customer.FreelancerPerson.Add(freelancer);
                db.SaveChanges();
            }
            return RedirectToAction("CustomerView", id);

        }

        public ActionResult DeleteFreelancer(int freelancerId, int customerId )
        {
            var customer = db.Customer.Find(customerId); 
            var freelancer = db.FreelancerPerson.Find(freelancerId);

            customer.FreelancerPerson.Remove(freelancer);

            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();

            //return RedirectToAction("CustomerView", freelancerId);
            return Redirect(Request.UrlReferrer.ToString());
        }


        public ActionResult AddWork(int? freelancerId)
        {
            //EducationsController educationsController = new EducationsController();
            return RedirectToAction("Create", "Works", new { freelancerId });
        }

        public ActionResult AddCompetence(int? freelancerId)
        {
            //EducationsController educationsController = new EducationsController();
            return RedirectToAction("Create", "Freelancer_Competence", new { freelancerId });
        }

        public ActionResult UpdateContacts(int? freelancerId)
        {
            return RedirectToAction("Edit", "FreelancerPersons", new { freelancerId });
        }

        public ActionResult UpdateOtherInfo(int? freelancerId)
        {
            return RedirectToAction("Edit", "OtherInfoes", new { freelancerId });
        }

        public ActionResult AddLanguage(int? freelancerId)
        {
            return RedirectToAction("Edit", "OtherInfoes", new { freelancerId });
        }

        #region Educations
        public ActionResult AddEducation(int? freelancerId)
        {
            return RedirectToAction("Create", "Educations", new { freelancerId });
        }
        public ActionResult UpdateEducation(int? id)
        {
            return RedirectToAction("Edit", "Educations", new { id });
        }

        public ActionResult DetailsEducation(int? id)
        {
            return RedirectToAction("Details", "Educations", new { id });
        }

        public ActionResult DeleteEducation(int? id)
        {
            return RedirectToAction("Delete", "Educations", new { id });
        }
        #endregion

        #region Work

        public ActionResult UpdateWork(int? id)
        {
            return RedirectToAction("Edit", "Works", new { id });
        }

        public ActionResult DetailsWork(int? id)
        {
            return RedirectToAction("Details", "Works", new { id });
        }

        public ActionResult DeleteWork(int? id)
        {
            return RedirectToAction("Delete", "Works", new { id });

        }

        #endregion
    }
}