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
    
    public partial class tblAppoinment
    {
        public int AppointmentID { get; set; }
        public string AppointmentStatus { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public System.DateTime Appointment_date { get; set; }
        public System.TimeSpan Appointment_time { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public System.DateTime BookedOn { get; set; }
        public string Reason { get; set; }
        public int SlotID { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsFinished { get; set; }
        public bool sCancelled { get; set; }
    }
}
