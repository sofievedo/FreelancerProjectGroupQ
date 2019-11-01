using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancerProject.Controllers
{
    
    public class ViewforProfileController : Controller
    {
        // GET: ViewforProfile

        private FreelancerEntities db = new FreelancerEntities();

        public ActionResult Index()
        {
            var freelancer = db.FreelancerPerson.Find(1);
            return View(freelancer);
        }
    }
}