using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelancerProject.Methods
{
    public static class SearchFreelancers
    {
        private static FreelancerEntities db = new FreelancerEntities();

        public static List<FreelancerPerson> SearchFreelancer(string searchWord)
        {
            searchWord = searchWord.ToLower();

            List<int> matchingEducations = GetFreelancerIDWithMatchingEducations(searchWord);
            List<int> matcingWorks = GetFreelancerIDWithMatchingWorks(searchWord);
            List<int> matchingCompetences = GetFreelancerIDWithMatchingCompetences(searchWord);

            List<int> matchingIDs = matchingCompetences.Union(matchingEducations).ToList().Union(matcingWorks).ToList();

            return ListOFMatchingFreelancers(matchingIDs);
        }

        private static List<int> GetFreelancerIDWithMatchingEducations(string searchWord)
        {
            return db.Education.Where(e => e.Subject.ToLower().Contains(searchWord)).Select(e => e.FreelancerId).ToList();
        }

        private static List<int> GetFreelancerIDWithMatchingWorks(string searchWord)
        {
            return db.Work.Where(w => w.Role.ToLower().Contains(searchWord)).Select(w => w.FreelancerId).ToList();
        }

        private static List<int> GetFreelancerIDWithMatchingCompetences(string searchWord)
        {
            return db.Freelancer_Competence.Where(c => c.Competence.CompetenceName.ToLower().Contains(searchWord)).Select(c => c.FreelancerId).ToList();
        }

        private static List<FreelancerPerson> ListOFMatchingFreelancers(List<int> matchingIDs)
        {
            List<FreelancerPerson> matchedFreelancers = new List<FreelancerPerson>();

            foreach (var freelancerId in matchingIDs)
            {
                matchedFreelancers.Add(db.FreelancerPerson.Find(freelancerId));
            }

            return matchedFreelancers;
        }


    }
}