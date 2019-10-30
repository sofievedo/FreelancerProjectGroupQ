using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelancerProject.ViewModels
{
    public class Test
    {

        private FreelancerEntities db = new FreelancerEntities();


        public FreelancerPerson Freelancer { get; set; }
       // public List<Education> Educations { get; set; }

        private List<string> work;

        public List<string> Works
        {
            get
            {
                List<string> workList = new List<string>();
                foreach (var item in Freelancer.Work)
                {
                    workList.Add(item.Id.ToString() + "\n") ;
                }

                return workList;

            }
            set { work = value; }
        }

        private IEnumerable<Education> educations;

        public IEnumerable<Education> Educations
        {
            get { return Freelancer.Education; }
            set { educations = value; }
        }


        public Test(int id = 1) //TODO: Ta bort värde
        {
            Freelancer = db.FreelancerPerson.Find(id);
           // Educations = db.Education.Where(f => f.FreelancerId == id).ToList();
        }

    }
}