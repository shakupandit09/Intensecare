//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntenseCare.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPatient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pin { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public bool IsMobileVerified { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> DateOFBirth { get; set; }
        public string History { get; set; }
        public Nullable<int> ReferencedBy { get; set; }
        public string NomineeName { get; set; }
        public string NomineeContactNo { get; set; }
        public byte[] NomineeAddress { get; set; }
    }
}
