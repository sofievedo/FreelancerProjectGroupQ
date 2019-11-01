using FreelancerProject.Models;
using FreelancerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancerProject.Controllers
{
    public class Freelancer_CompetenceController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();
        private FreelancerCompetenceViewModel vm = new FreelancerCompetenceViewModel();
        // GET: Freelancer_Competence
        public ActionResult Create(int? freelancerId = 1) //TODO: Ta bort variabeln
        {
            List<Role> roles = db.Role.ToList();
            List<int> rankingList = new List<int>() { 1, 2, 3, 4, 5 };
            ViewBag.Roles = new SelectList(roles, "Id", "RoleName");
            ViewBag.Ranking = new SelectList(rankingList);
            return View();
        }

        public JsonResult GetCompetenceList(int RoleId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Competence> competences = db.Competence.Where(x => x.RoleId == RoleId).ToList();
            return Json(competences, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FreelancerId,CompetenceId,Ranking")] FreelancerCompetenceViewModel viewModel)
        {
            Freelancer_Competence freelancer_Competence = new Freelancer_Competence()
            {
                CompetenceId = viewModel.CompetenceId,
                FreelancerId = viewModel.FreelancerId,
                Ranking = viewModel.Ranking

            };

            if (ModelState.IsValid)
            {
                db.Freelancer_Competence.Add(freelancer_Competence);
                db.SaveChanges();
                return RedirectToAction("Index", "FreelancerCV", new { freelancer_Competence.FreelancerId });
            }

            ViewBag.FreelancerId = new SelectList(db.FreelancerPerson, "Id", "Firstname", freelancer_Competence.FreelancerId);
            return View(freelancer_Competence);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}