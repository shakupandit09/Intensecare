﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AppointmentEntities10 : DbContext
    {
        public AppointmentEntities10()
            : base("name=AppointmentEntities10")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CityMaster> CityMasters { get; set; }
        public DbSet<CountryMaster> CountryMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<tblAchievement> tblAchievements { get; set; }
        public DbSet<tblAdmin> tblAdmins { get; set; }
        public DbSet<tblAdminIquiry> tblAdminIquiries { get; set; }
        public DbSet<tblAdmitDetail> tblAdmitDetails { get; set; }
        public DbSet<tblAppoinment> tblAppoinments { get; set; }
        public DbSet<tblCMSPage> tblCMSPages { get; set; }
        public DbSet<tblDiagnoseDetail> tblDiagnoseDetails { get; set; }
        public DbSet<tblDoctor> tblDoctors { get; set; }
        public DbSet<tblDoctorAbsence> tblDoctorAbsences { get; set; }
        public DbSet<tblDoctorInquiry> tblDoctorInquiries { get; set; }
        public DbSet<tblDoctorSlot> tblDoctorSlots { get; set; }
        public DbSet<tblFeedback> tblFeedbacks { get; set; }
        public DbSet<TblInHouseTreatement> TblInHouseTreatements { get; set; }
        public DbSet<tblNewsLetter> tblNewsLetters { get; set; }
        public DbSet<tblPatientDetail> tblPatientDetails { get; set; }
        public DbSet<tblPayment> tblPayments { get; set; }
        public DbSet<tblPrescription> tblPrescriptions { get; set; }
        public DbSet<tblPrescriptionDetail> tblPrescriptionDetails { get; set; }
        public DbSet<tblReview> tblReviews { get; set; }
        public DbSet<tblPatient> tblPatients { get; set; }
        public DbSet<tblNurse> tblNurses { get; set; }
    }
}
