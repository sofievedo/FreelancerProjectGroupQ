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
    using System.ComponentModel;

    public partial class OtherInfo
    {
        public int Id { get; set; }
        public int FreelancerId { get; set; }
        [DisplayName("Innehar körtkortstyper")]
        public string DriversLicence { get; set; }
        [DisplayName("Språk")]
        public string Languages { get; set; }
        [DisplayName("Kärnförmågor")]
        public string CoreCompetences { get; set; }
        [DisplayName("Min profil")]
        public string ProfileMessage { get; set; }

        public string TestText { get; set; }
    
        public virtual FreelancerPerson FreelancerPerson { get; set; }
    }
}
