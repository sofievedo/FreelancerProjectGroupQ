using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreelancerProject.ViewModels;
using FreelancerProject.Controllers;

namespace FreelancerProject.Controllers
{
    public class FreelancerCVController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();

        // GET: FreelancerCV
        public ActionResult Index()
        {
            int id = 1; //TODO: Ta bort hårdkodning
            var freelancer = new FreelancerCVViewmodel(id);

            return View(freelancer);
        }

        public ActionResult AddEducation(int? freelancerId)
        {
            //EducationsController educationsController = new EducationsController();
            return RedirectToAction("Create", "Educations", new { freelancerId });
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



    }
}