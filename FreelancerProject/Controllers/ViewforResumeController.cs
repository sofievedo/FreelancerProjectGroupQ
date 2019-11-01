using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancerProject.Controllers
{
    public class ViewforResumeController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();
        // GET: ViewforResume
        public ActionResult Index()
        {
            var freelancer = db.FreelancerPerson.Find(1);
            return View(freelancer);
        }
    }
}