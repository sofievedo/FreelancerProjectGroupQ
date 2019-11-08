using FreelancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelancerProject.Methods
{
    public static class GetStringListForAutoComplete
    {
        private static FreelancerEntities db = new FreelancerEntities();

        public static List<string> SearchFreelancer(string searchWord)
        {
            searchWord = searchWord.ToLower();

            List<string> matchingEducations = GetFreelancerIDWithMatchingEducations(searchWord);
            List<string> matcingWorks = GetFreelancerIDWithMatchingWorks(searchWord);
            List<string> matchingCompetences = GetFreelancerIDWithMatchingCompetences(searchWord);
            List<string> matchingCoreCompetence = GetFreelancerIDWithMatchingCoreCompetences(searchWord);
            List<string> matchingIDs = matchingCompetences.Union(matchingEducations).ToList().Union(matcingWorks).ToList().Union(matchingCoreCompetence).ToList();

            return matchingIDs;
        }

        private static List<string> GetFreelancerIDWithMatchingEducations(string searchWord)
        {
            return db.Education.Where(e => e.Subject.ToLower().Contains(searchWord)).Select(e => e.Subject).ToList();
        }

        private static List<string> GetFreelancerIDWithMatchingWorks(string searchWord)
        {
            return db.Work.Where(w => w.Role.ToLower().Contains(searchWord)).Select(w => w.Role).ToList();
        }

        private static List<string> GetFreelancerIDWithMatchingCompetences(string searchWord)
        {
            return db.Freelancer_Competence.Where(c => c.Competence.CompetenceName.ToLower().Contains(searchWord)).Select(c => c.Competence.CompetenceName).ToList();
        }

        private static List<string> GetFreelancerIDWithMatchingCoreCompetences(string searchWord)
        {
            return db.OtherInfo.Where(i => i.CoreCompetences.ToLower().Contains(searchWord)).Select(c => c.CoreCompetences).ToList();
        }

        //private static List<FreelancerPerson> ListOFMatchingFreelancers(List<string> matchingIDs)
        //{
        //    List<FreelancerPerson> matchedFreelancers = new List<FreelancerPerson>();

        //    foreach (var freelancerId in matchingIDs)
        //    {
        //        matchedFreelancers.Add(db.FreelancerPerson.Find(freelancerId));
        //    }

        //    return matchedFreelancers;
        //}




    }
}