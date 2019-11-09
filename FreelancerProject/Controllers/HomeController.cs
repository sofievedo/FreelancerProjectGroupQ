using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancerProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginInAsFreelancer(int id = 1)
        {
            Session["userType"] = 1;
            Session["freelancerId"] = id;

           return RedirectToAction("Index", "Profilefreelancer");
        }

        public ActionResult LoginInAsCostumer(int id = 1)
        {
            Session["userType"] = 2;
            Session["customerId"] = id;

            return RedirectToAction("FilterFreelancers", "FreelancerPersons");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hjälper dig hitta hjälpen du behöver! ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();//Test uppladdning
        }
    }
}