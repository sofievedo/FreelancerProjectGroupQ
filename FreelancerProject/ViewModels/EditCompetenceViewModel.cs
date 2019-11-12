using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancerProject.ViewModels
{
    public class EditCompetenceViewModel
    {
        private FreelancerEntities db = new FreelancerEntities();

        public Freelancer_Competence Freelancer_Competence { get; set; }

        private string competenceName;

        [DisplayName("Kompetens")]
        public string CompetenceName
        {
            get { return competenceName; }
            set { competenceName = value; }
        }
        
        public int Ranking { get; set; }

        public int CompetenceId { get; set; }

        public int FreelancerId { get; set; }

        public List<int> RankingList = new List<int>() { 1, 2, 3, 4, 5 };

        public EditCompetenceViewModel(int? competenceID, int? freelanderID)
        {
            CompetenceId = Convert.ToInt32(competenceID);
            FreelancerId = Convert.ToInt32(freelanderID);
            Freelancer_Competence = db.Freelancer_Competence.FirstOrDefault(c => c.FreelancerId == freelanderID && c.CompetenceId == competenceID);
            CompetenceName = Freelancer_Competence.Competence.CompetenceName;

        }

        public EditCompetenceViewModel()
        {

        }

    }
}