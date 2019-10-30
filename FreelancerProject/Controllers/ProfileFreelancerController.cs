using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreelancerProject.Models;

namespace FreelancerProject.Controllers
{
    public class ProfileFreelancerController : Controller
    {

      
        private FreelancerEntities db = new FreelancerEntities();
        // GET: ProfileFreelancer
        public ActionResult Index()
        {

            var freelancer = db.FreelancerPerson.Find(1);
            return View();
        }

      
    }
}