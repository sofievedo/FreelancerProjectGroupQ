//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FreelancerProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Freelancer_Competence
    {
        public int FreelancerId { get; set; }
        public int CompetenceId { get; set; }
        public Nullable<int> Ranking { get; set; }
    
        public virtual Competence Competence { get; set; }
        public virtual FreelancerPerson FreelancerPerson { get; set; }
    }
}
