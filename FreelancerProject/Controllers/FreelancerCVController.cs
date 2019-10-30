using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreelancerProject.ViewModels;

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
    }
}