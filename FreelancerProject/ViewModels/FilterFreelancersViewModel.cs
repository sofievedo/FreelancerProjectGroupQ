using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelancerProject.ViewModels
{
    public class FilterFreelancersViewModel
    {
        private FreelancerEntities db = new FreelancerEntities();

        public int CompetenceId { get; set; }
        public int? FreelancerId { get; set; }
        public int RoleId { get; set; }
        public List<FreelancerPerson> Freelancers { get; set; }

        public List<Competence> Competences { get
            {
                return db.Competence.ToList();
            }
        }

        public Competence Competence{get; set;}

        public string SearchWord { get; set; }

        public List<int> RankingList = new List<int> { 1, 2, 3, 4, 5 };

        public int LowestRankToFilter{ get; set; }

        public FilterFreelancersViewModel()
        {
           
        }
    }
}