using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

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

        private int ranking;

        public int Ranking
        {
            get { return ranking; }
            set
            {
                db.Freelancer_Competence.Add(new Freelancer_Competence()
                {
                    Ranking = ranking,
                    CompetenceId = CompetenceId
                });
            }
        }


        public int CompetenceId { get; set; }

        public int FreelancerId { get; set; }

        public EditCompetenceViewModel(int? competenceID)
        {
            CompetenceId = Convert.ToInt32(competenceID);
            Freelancer_Competence = db.Freelancer_Competence.FirstOrDefault(c => c.CompetenceId == competenceID);
            CompetenceName = Freelancer_Competence.Competence.CompetenceName;

        }

    }
}