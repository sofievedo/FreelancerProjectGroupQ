using FreelancerProject.Models;
using FreelancerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FreelancerProject.Controllers
{
    public class Freelancer_CompetenceController : Controller
    {
        private FreelancerEntities db = new FreelancerEntities();

        // GET: Freelancer_Competence

        [HttpGet]
        public ActionResult Create(int? freelancerId = 1) //TODO: Ta bort variabeln
        {
            List<Role> roles = db.Role.ToList();
            List<int> rankingList = new List<int>() { 1, 2, 3, 4, 5 };
            ViewBag.FreelancerId = freelancerId;
            ViewBag.Roles = new SelectList(roles, "Id", "RoleName");
            ViewBag.Ranking = new SelectList(rankingList);

            FreelancerCompetenceViewModel viewModel = new FreelancerCompetenceViewModel(freelancerId);

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FreelancerId,CompetenceId,Ranking")] FreelancerCompetenceViewModel viewModel)
        {
            Freelancer_Competence freelancer_Competence = new Freelancer_Competence()
            {
                CompetenceId = viewModel.CompetenceId,
                FreelancerId = Convert.ToInt32(viewModel.FreelancerId),
                Ranking = viewModel.Ranking

            };

            if (ModelState.IsValid)
            {
                db.Freelancer_Competence.Add(freelancer_Competence);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    //TODO:Fixa felmeddelande
                    // RedirectToAction("Create", viewModel.FreelancerId);
                }

                return RedirectToAction("Create", viewModel.FreelancerId);
            }

            ViewBag.FreelancerId = new SelectList(db.FreelancerPerson, "Id", "Firstname", freelancer_Competence.FreelancerId);
            return View(freelancer_Competence);
        }

        public JsonResult GetCompetenceList(int RoleId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Competence> competences = db.Competence.Where(x => x.RoleId == RoleId).ToList();
            return Json(competences, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id, int freelancerId)
        {
            //if (competenceId == null || freelancerId == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}           
            
            List<int> rankingList = new List<int>() { 1, 2, 3, 4, 5 };
            ViewBag.Ranking = new SelectList(rankingList);
            return View(new EditCompetenceViewModel(id, freelancerId) );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(EditCompetenceViewModel viewModel)
        {     
            Freelancer_Competence updatedComptence = new Freelancer_Competence()
            {
                FreelancerId = viewModel.FreelancerId,
                CompetenceId = viewModel.CompetenceId,
                Ranking = viewModel.Ranking
            };

            if (ModelState.IsValid)
            {
                db.Entry(updatedComptence).State = EntityState.Modified; //TODO: lägg till säkerhetsfunktioner
                db.SaveChanges();
                return RedirectToAction("Index", "FreelancerCV", new { viewModel.FreelancerId });
            }
            List<int?> rankingList = new List<int?>() { 1, 2, 3, 4, 5 }; //TODO: använd lista från viewmodel istället. 

            ViewBag.Ranking = new SelectList(rankingList);
            return View(viewModel);
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