using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancerProject.Controllers
{
    public class ProfileFreelancerController : Controller
    {

      
        private FreelancerEntities db = new FreelancerEntities();
        // GET: ProfileFreelancer
        public ActionResult Index(int? id)
        {

            var freelancer = db.FreelancerPerson.Find(id);

            return View(freelancer);
        }

      
    }
}