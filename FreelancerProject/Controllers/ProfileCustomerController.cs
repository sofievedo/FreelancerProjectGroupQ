using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancerProject.Controllers
{
    public class ProfileCustomerController : Controller
    {

        private FreelancerEntities db = new FreelancerEntities();
        // GET: ProfileFreelancer
        public ActionResult Index()
        {

            var customer = db.Customer.Find(1);

            return View(customer);
        }

    }
}