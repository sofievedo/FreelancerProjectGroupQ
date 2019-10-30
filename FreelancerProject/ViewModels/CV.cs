using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreelancerProject.Models;

namespace FreelancerProject.ViewModels
{
    public class CV
    {
        public Education Education { get; set; }

        private Competence competence;

        public Competence Competence
        {
            get { return competence; }
            set { competence = value; }
        }

    }
}