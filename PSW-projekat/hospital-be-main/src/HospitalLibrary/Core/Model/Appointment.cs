using System;

namespace HospitalLibrary.Core.Model
{
    public class Appointment : BaseModel
    {
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime CancelationDate { get; set; }

        public Appointment() { }

        public Appointment(int id) 
        {
            Id = id;
        }


        public Appointment(int id, bool deleted, Patient patient, Doctor doctor, DateTime dateTime, DateTime cancelationDate)
        {
            Id = id;
            Deleted = deleted;
            Patient = patient;
            Doctor = doctor;
            DateTime = dateTime;
            CancelationDate = cancelationDate;

        }
    }

}
