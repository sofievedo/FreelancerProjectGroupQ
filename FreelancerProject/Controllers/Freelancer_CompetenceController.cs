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
        public ActionResult Create(int? freelancerId)
        {
            List<Role> roles = db.Role.ToList();
            ViewBag.Roles = new SelectList(roles, "Id", "RoleName");
            List<int> rankingList = new List<int>() { 1, 2, 3, 4, 5 };
            ViewBag.Ranking = new SelectList(rankingList);
            ViewBag.FreelancerId = freelancerId;

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
                try
                {
                    db.Freelancer_Competence.Add(freelancer_Competence);
                    db.SaveChanges();
                    RedirectToAction("Index", "FreelancerCV", new { id = viewModel.FreelancerId });
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
            List<int> rankingList = new List<int>() { 1, 2, 3, 4, 5 };
            ViewBag.Ranking = new SelectList(rankingList);
            return View(new EditCompetenceViewModel(id, freelancerId) );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCompetenceViewModel viewModel)//TODO: lägg till bind
        {     
            Freelancer_Competence updatedComptence = new Freelancer_Competence()
            {
                FreelancerId = viewModel.FreelancerId,
                CompetenceId = viewModel.CompetenceId,
                Ranking = viewModel.Ranking
            };

            if (ModelState.IsValid)
            {
                db.Entry(updatedComptence).State = EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index", "FreelancerCV", new { viewModel.FreelancerId });
            }
            List<int?> rankingList = new List<int?>() { 1, 2, 3, 4, 5 }; 

            ViewBag.Ranking = new SelectList(rankingList);
            return View(viewModel);
        }

        public ActionResult Delete(int? id, int? freelancerId)
        {
            if (id == null || freelancerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freelancer_Competence freelancer_CompetenceMatch = db.Freelancer_Competence.Where(c => c.CompetenceId == id)
                                                                .Where(c => c.FreelancerId == freelancerId).FirstOrDefault() ;
            if (freelancer_CompetenceMatch == null)
            {
                return HttpNotFound();
            }
            return View(freelancer_CompetenceMatch);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int freelancerId)
        {
            Freelancer_Competence freelancer_Competence = db.Freelancer_Competence.Where(c => c.CompetenceId == id).Where(c => c.FreelancerId == freelancerId).FirstOrDefault();
            db.Freelancer_Competence.Remove(freelancer_Competence);
            db.SaveChanges();
            return RedirectToAction("Index", "FreelancerCV", new { freelancer_Competence.FreelancerId });
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