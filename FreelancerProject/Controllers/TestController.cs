using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreelancerProject.ViewModels;
using FreelancerProject.Models;

namespace FreelancerProject.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            Test test = new Test(); 
            return View(test);
        }
    }
}