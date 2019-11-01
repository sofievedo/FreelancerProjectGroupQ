using FreelancerProject.Models;
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

        // GET: Freelancer_Competence
        public ActionResult Index(int? freelancerId = 1) //TODO: Ta bort variabeln
        {
            List<Role> roles = db.Role.ToList();
            ViewBag.Roles = new SelectList(roles, "Id", "RoleName");
            return View();
        }

        public JsonResult GetCompetenceList(int RoleId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Competence> competences = db.Competence.Where(x => x.RoleId == RoleId).ToList();
            return Json(competences, JsonRequestBehavior.AllowGet);
        }
    }
}