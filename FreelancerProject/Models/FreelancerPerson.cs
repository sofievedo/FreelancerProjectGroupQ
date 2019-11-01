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

    public partial class FreelancerPerson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FreelancerPerson()
        {
            this.Education = new HashSet<Education>();
            this.Freelancer_Competence = new HashSet<Freelancer_Competence>();
            this.OtherInfo = new HashSet<OtherInfo>();
            this.Work = new HashSet<Work>();
            this.Customer = new HashSet<Customer>();
            this.Languages = new HashSet<Languages>();
        }
    
        public int Id { get; set; }

        [DisplayName("F�rnamn")]
        public string Firstname { get; set; }
        [DisplayName("Efternamn")]
        public string Lastname { get; set; }
        [DisplayName("F�delsedatum")]
        public Nullable<System.DateTime> Birthday { get; set; }
        [DisplayName("Nationalitet")]
        public string Nationality { get; set; }
        [DisplayName("Gatuadress")]
        public string Address { get; set; }
        [DisplayName("Postnummer")]
        public string ZipCode { get; set; }
        [DisplayName("Ort")]
        public string City { get; set; }
        [DisplayName("Telefonnummer")]
        public string Phonenumber { get; set; }
        [DisplayName("Mailadress")]
        public string Email { get; set; }
        [DisplayName("Linked In")]
        public string LinkToLinkedIn { get; set; }
        [DisplayName("Git Hub")]
        public string LinkToGithub { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Education { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Freelancer_Competence> Freelancer_Competence { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtherInfo> OtherInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Work> Work { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Languages> Languages { get; set; }
    }
}
