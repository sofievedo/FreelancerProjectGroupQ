using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelancerProject.ViewModels
{
    public class FreelancerCompetenceViewModel
    {
        public int RoleId { get; set; }

        public int CompetenceId { get; set; }

        public ICollection<Role> Roles { get; set; }
        public ICollection<Competence> Competences { get; set; }
    }
}