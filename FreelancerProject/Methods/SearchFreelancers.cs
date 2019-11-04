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
        private static List<FreelancerPerson> matchedFreelancers;
        private static string thisSearchWord;

        //TODO: Borde man söka genom alla utbildningar, jobb, etc. istället? 

        public static List<FreelancerPerson> SearchFreelancer(string searchWord)
        {
            var allFreelancers = db.FreelancerPerson.ToList();
            thisSearchWord = searchWord.ToLower();
            matchedFreelancers = new List<FreelancerPerson>();

            var matchingEducations = getMatchingEducations();
            var matcingWorks = getMatchingWorks();
            var matchingCompetences = getMatchingCompetences();

            var matched = matchingEducations.Except(matchingCompetences).Except(matcingWorks);

            foreach (var freelancerId in matched)
            {
                matchedFreelancers.Add(db.FreelancerPerson.Find(freelancerId));
            }

            return matchedFreelancers;
        }

        private static List<int> getMatchingCompetences()
        {
            return db.Freelancer_Competence.Where(c => c.Competence.CompetenceName.ToLower() == thisSearchWord).Select(c => c.FreelancerId).ToList();
        }

        private static List<int> getMatchingWorks()
        {
            return db.Work.Where(w => w.Role.ToLower() == thisSearchWord).Select(w => w.FreelancerId).ToList();
        }

        private static List<int> getMatchingEducations()
        {

            return db.Education.Where(e => e.Subject.ToLower() == thisSearchWord).Select(e => e.FreelancerId).ToList();


        }
    }
}