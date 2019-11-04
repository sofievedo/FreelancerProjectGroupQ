using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelancerProject.ViewModels
{
    public class FreelancerCompetenceViewModel
    {

        private FreelancerEntities db = new FreelancerEntities();


        public int RoleId { get; set; }

        public int CompetenceId { get; set; }
        public int? FreelancerId { get; set; }

        public string ExceptionMessage { get; set; }


        public int Ranking { get; set; }



        public Freelancer_Competence Freelancer_Competence { get; set; }
        public FreelancerPerson Freelancer { get; set; }

        public List<Freelancer_Competence> FreelancersCompetences { get; set; }

        public FreelancerCompetenceViewModel(int? id = 1) //TODO: Ta bort hårdkodning
        {
            Freelancer = db.FreelancerPerson.Find(id);
            FreelancersCompetences = db.Freelancer_Competence.Where(f => f.FreelancerId == id).ToList();
            FreelancerId = id;


        }

        public FreelancerCompetenceViewModel() 
        {

        }
    }
}