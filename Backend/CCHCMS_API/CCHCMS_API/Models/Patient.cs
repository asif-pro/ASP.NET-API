//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCHCMS_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.Prescriptions = new HashSet<Prescription>();
        }
    
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string Name { get; set; }
        public System.DateTime Dob { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public int HealthCard { get; set; }
        public string BloodGroup { get; set; }
        public string BornDisease { get; set; }
        public string BirthMark { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
