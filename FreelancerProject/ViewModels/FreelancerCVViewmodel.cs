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
        public Customer Customer { get; set; }


        private string birthdayString;

        public string BirtdayString
        {
            get
            {
                var birthday = Convert.ToDateTime(Freelancer.Birthday);
                return birthday.ToString("yyyy-MM-dd");
            }
            set { birthdayString = value; }
        }


        public ICollection<Languages> Languages
        {
            get { return Freelancer.Languages; }
            set { Freelancer.Languages = value; }
        }

        public ICollection<Education> Educations
        {
            get { return Freelancer.Education; }
            set { Freelancer.Education = value; }
        }

        public ICollection<Work> Works
        {
            get { return Freelancer.Work; }
            set { Freelancer.Work = value; }
        }

        public OtherInfo OtherInfo
        {
            get { return db.OtherInfo.Where(f => f.FreelancerId == Freelancer.Id).FirstOrDefault(); }
        }

        public IOrderedEnumerable<Freelancer_Competence> SortedCompetenceList
        {
            get
            {
                return Freelancer.Freelancer_Competence.OrderByDescending(c => c.Ranking);
            }
        }


        public bool FreelancerIsSaved
        {
            get {
                if (Customer.FreelancerPerson.Contains(Freelancer))
                {
                    return true;
                }
                else
                {
                    return false;
                }}
        }




        public FreelancerCVViewmodel(int? id = 1) //TODO: Ta bort hårdkodning
        {
            Freelancer = db.FreelancerPerson.Find(id);
        }
        public FreelancerCVViewmodel(int? freelancerId, int customerId) //TODO: Ta bort hårdkodning
        {
            Freelancer = db.FreelancerPerson.Find(freelancerId);
            Customer = db.Customer.Find(customerId); 
        }
    }
}