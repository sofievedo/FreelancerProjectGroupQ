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
        private FreelancerPerson free = new FreelancerPerson();

        // GET: ProfileFreelancer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var firstname = free.Firstname;
            var lastname = free.Lastname;
            var address = free.Address;
            var phone = free.Phonenumber;
            var email = free.Email;
            var link1 = free.LinkToGithub;
            var link2 = free.LinkToLinkedIn;

            return View();
        }
    }
}