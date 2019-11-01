using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelancerProject.ViewModels
{
    public class FreelancerCVViewmodel
    {
        private FreelancerEntities db = new FreelancerEntities();

        public FreelancerPerson Freelancer { get; set; }

        private ICollection<Languages> languages;

        public ICollection<Languages> Languages
        {
            get { return Freelancer.Languages; }
            set { Freelancer.Languages = value; }
        }


        private ICollection<Education> educations;

        public ICollection<Education> Educations
        {
            get { return Freelancer.Education; }
            set { Freelancer.Education = value; }
        }
        
        private ICollection<Work> works;

        public ICollection<Work> Works
        {
            get { return Freelancer.Work; }
            set { Freelancer.Work = value; }
        }

        private OtherInfo otherInfo;

        public OtherInfo OtherInfo
        {
            get { return db.OtherInfo.Where(f => f.FreelancerId == Freelancer.Id).FirstOrDefault(); }
            set { otherInfo = value; } //TODO: Har ingen fungerande setmetod
        }





        public FreelancerCVViewmodel(int id = 1) //TODO: Ta bort hårdkodning
        {
            Freelancer = db.FreelancerPerson.Find(id);
        }
    }
}