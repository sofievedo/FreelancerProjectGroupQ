using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancerProject.Controllers
{
    public class VyforprofileController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();
        // GET: Vyforprofile
        public ActionResult Index(int? freelancerId)
        {
            var freelancer = db.FreelancerPerson.Find(freelancerId);

            return View(freelancer);
        }
    }
}