using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntenseCare.Models
{
    public class Datamodel
    {
        public tblAdmin admin { get; set; }
        public tblDoctor Doctor { get; set; }
        public tblDoctorAbsence Absence { get; set; }
        public tblAchievement Achieve { get; set; }
        public tblDoctorSlot Slot { get; set; }
        public TblInHouseTreatement HTreat { get; set; }
        public tblPatient Patient { get; set; }
        public tblAppoinment Appoint { get; set; }
        public tblAdmitDetail Admit { get; set; }
        public tblNurse Nurse { get; set; }
        public tblDiagnoseDetail Diagnose { get; set; }
        public tblPayment payment { get; set; }
        public tblPrescription Prescription { get; set; }
        public tblPrescriptionDetail PresDetail { get; set; }
        public tblReview Review { get; set; }
        public tblPatientDetail patientDetail { get; set; }
        public tblDoctorInquiry  DoctorInquiry { get; set; }

    }
}