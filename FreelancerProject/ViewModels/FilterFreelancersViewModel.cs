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

        public FilterFreelancersViewModel()
        {
           
        }
    }
}