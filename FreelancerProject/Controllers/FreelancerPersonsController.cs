using FreelancerProject.Methods;
using FreelancerProject.Models;
using FreelancerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace FreelancerProject.Controllers
{
    public class FreelancerPersonsController : Controller
    {
        FreelancerEntities db = new FreelancerEntities();


        // GET: FreelancerPersons
        public ActionResult Index()
        {
            TempData["searchWord"] = "";
            return View(db.FreelancerPerson.ToList());
        }
        public ActionResult Vy(int? freelancerId)
        {
            return RedirectToAction("Index", "Vyforprofile", new { freelancerId = freelancerId });
        }


        [HttpPost]
        public ActionResult Index(string searchWord)
        {
            if (ModelState.IsValid)
            {
                return View(SearchFreelancers.GetFreelancersList(searchWord));
            }

            return View(db.FreelancerPerson.ToList());
        }

        //GET: FreelancerPersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerPerson freelancerPerson = db.FreelancerPerson.Find(id);
            if (freelancerPerson == null)
            {
                return HttpNotFound();
            }
            return View(freelancerPerson);
        }

        // GET: FreelancerPersons/Create
        public ActionResult Create()
        {
            return View();
        }
        //[HttpPut]
        //public ActionResult Create(int freelancerId)
        //{
        //    var freelancer = db.FreelancerPerson.Find(freelancerId);
        //    return View(freelancer);
        //}

        // POST: FreelancerPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Firstname,Lastname,Birthday,Nationality,Address,ZipCode,City,Phonenumber,Email,LinkToLinkedIn,LinkToGithub")] FreelancerPerson freelancerPerson)
        {
            if (ModelState.IsValid)
            {
                db.FreelancerPerson.Add(freelancerPerson);
                db.SaveChanges();
                return RedirectToAction("Create", "OtherInfoes", new { freelancerId = freelancerPerson.Id });
            }

            return View(freelancerPerson);
        }

        // GET: FreelancerPersons/Edit/5
        public ActionResult Edit(int? freelancerId)
        {
            if (freelancerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerPerson freelancerPerson = db.FreelancerPerson.Find(freelancerId);
            if (freelancerPerson == null)
            {
                return HttpNotFound();
            }
            return View(freelancerPerson);
        }

        // POST: FreelancerPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,Birthday,Nationality,Address,ZipCode,City,Phonenumber,Email,LinkToLinkedIn,LinkToGithub")] FreelancerPerson freelancerPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freelancerPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "FreelancerCV", new { freelancerPerson.Id });
            }
            return View(freelancerPerson);
        }

        // GET: FreelancerPersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerPerson freelancerPerson = db.FreelancerPerson.Find(id);
            if (freelancerPerson == null)
            {
                return HttpNotFound();
            }
            return View(freelancerPerson);
        }

        // POST: FreelancerPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FreelancerPerson freelancerPerson = db.FreelancerPerson.Find(id);
            db.FreelancerPerson.Remove(freelancerPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FilterFreelancers()
        {

            var viewModel = new FilterFreelancersViewModel
            {
                Freelancers = db.FreelancerPerson.ToList() //TODO: Fortsätt här. Söka på ranking
            };
            ViewBag.Ranking = new SelectList(viewModel.RankingList);
            List<Role> roles = db.Role.ToList();
            ViewBag.Roles = new SelectList(roles, "Id", "RoleName");

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult FilterFreelancers(FilterFreelancersViewModel vm)
        {
            List<Role> roles = db.Role.ToList();
            ViewBag.Roles = new SelectList(roles, "Id", "RoleName");
            ViewBag.Ranking = new SelectList(vm.RankingList);

            if (vm.SearchWord != null)
            {
                return View(FindFreelancersBySearchWord(vm));
            }

            else
            {
                return View(FindFreelancersByCompetence(vm));
            }

        }

        private FilterFreelancersViewModel FindFreelancersBySearchWord(FilterFreelancersViewModel vm)
        {
            var newViewModel = new FilterFreelancersViewModel();

            var matches = SearchFreelancers.GetFreelancersList(vm.SearchWord);

            newViewModel.Freelancers = matches;

            return newViewModel;

        }

        private FilterFreelancersViewModel FindFreelancersByCompetence(FilterFreelancersViewModel vm)
        {
            var newViewModel = new FilterFreelancersViewModel
            {
                Freelancers = db.Freelancer_Competence.Where(c => c.CompetenceId == vm.CompetenceId 
                                                             && c.Ranking >= vm.LowestRankToFilter)
                                                             .Select(x => x.FreelancerPerson).ToList()
                                                             //TODO: Bättre att dela upp i flera frågor? 
            };

            return newViewModel;
        }

        public ActionResult SearchCategory(string term)
        {
            var result = SearchFreelancers.GetStringList(term);

            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
