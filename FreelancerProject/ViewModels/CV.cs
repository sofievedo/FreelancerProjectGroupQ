﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreelancerProject.Models;

namespace FreelancerProject.ViewModels
{
    public class CV
    {
        private FreelancerEntities db = new FreelancerEntities();


        #region Properties

        public FreelancerPerson Freelancer { get; set; }
        public IEnumerable<Education> Educations { get; set; }
        public IEnumerable<Work> Works { get; set; }
        public  OtherInfo OtherInfo { get; set; }
        public IEnumerable<Freelancer_Competence> Freelancer_Competences { get; set; }



        //private Competence competence;

        //public  Competence Competence
        //{
        //    get { return competence; }
        //    set {
        //        //Sätta kompetens baserat på ID?
        //        competence = value; }
        //}

        //private Education education;

        //public Education Education
        //{
        //    get { return education; }
        //    set { education = value; }
        //}

        //private OtherInfo otherInfo;

        //public OtherInfo OtherInfo
        //{
        //    get { return otherInfo; }
        //    set { otherInfo = value; }
        //}

        //private Work work;

        //public Work Work
        //{
        //    get { return work; }
        //    set { work = value; }
        //}

        //private Freelancer_Competence freelancer_Competence;

        //public Freelancer_Competence Freelancer_Competence
        //{
        //    get { return freelancer_Competence; }
        //    set { freelancer_Competence = value; }
        //}

        #endregion

        #region Constructors

        public CV(int id)
        {
            this.Freelancer = db.FreelancerPerson.Find(id);
            this.Educations = db.Education.Where(e => e.FreelancerId == id).ToList();
            this.Works = db.Work.Where(w => w.FreelancerId == id).ToList();
            this.Freelancer_Competences = db.Freelancer_Competence.Where(f => f.FreelancerId == id).ToList();
            this.OtherInfo = db.OtherInfo.Where(oi => oi.FreelancerId == id).FirstOrDefault();
        }



        #endregion






    }
}