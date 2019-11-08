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


        #region GetFreelancers
        public static List<FreelancerPerson> GetFreelancersList(string searchWord)
        {
            searchWord = searchWord.ToLower();

            List<int> matchingEducations = GetFreelancerIDWithMatchingEducations(searchWord);
            List<int> matcingWorks = GetFreelancerIDWithMatchingWorks(searchWord);
            List<int> matchingCompetences = GetFreelancerIDWithMatchingCompetences(searchWord);
            List<int> matchingCoreCompetence = GetFreelancerIDWithMatchingCoreCompetences(searchWord);
            List<int> matchingIDs = matchingCompetences.Union(matchingEducations).ToList().Union(matcingWorks).ToList().Union(matchingCoreCompetence).ToList();

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

        private static List<int> GetFreelancerIDWithMatchingCoreCompetences(string searchWord)
        {
            return db.OtherInfo.Where(i => i.CoreCompetences.ToLower().Contains(searchWord)).Select(c => c.FreelancerId).ToList();
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

        #endregion

        #region GetStringList

        public static List<string> GetStringList(string searchWord)
        {
            searchWord = searchWord.ToLower();

            List<string> matchingEducations = GetMatchingEducations(searchWord);
            List<string> matcingWorks = GetMatchingWorks(searchWord);
            List<string> matchingCompetences = GetMatchingCompetences(searchWord);
            List<string> matchingCoreCompetence = GetMatchingCoreCompetences(searchWord);
            List<string> matchingIDs = matchingCompetences.Union(matchingEducations).ToList().Union(matcingWorks).ToList().Union(matchingCoreCompetence).ToList();

            return matchingIDs;
        }

        private static List<string> GetMatchingEducations(string searchWord)
        {
            return db.Education.Where(e => e.Subject.ToLower().Contains(searchWord)).Select(e => e.Subject).ToList();
        }

        private static List<string> GetMatchingWorks(string searchWord)
        {
            return db.Work.Where(w => w.Role.ToLower().Contains(searchWord)).Select(w => w.Role).ToList();
        }

        private static List<string> GetMatchingCompetences(string searchWord)
        {
            return db.Freelancer_Competence.Where(c => c.Competence.CompetenceName.ToLower().Contains(searchWord)).Select(c => c.Competence.CompetenceName).ToList();
        }

        private static List<string> GetMatchingCoreCompetences(string searchWord)
        {
            return db.OtherInfo.Where(i => i.CoreCompetences.ToLower().Contains(searchWord)).Select(c => c.CoreCompetences).ToList();
        }
        #endregion


    }
}