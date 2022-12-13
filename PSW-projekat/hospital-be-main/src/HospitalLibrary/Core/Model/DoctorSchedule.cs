using HospitalLibrary.Core.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace HospitalLibrary.Core.Model
{
    [Owned]
    public class DoctorSchedule : ValueObject
    {
        public int DoctorId { get; set; }
        public Day Day { get; set; }
        public TimeRange Shift { get; set; }

        public DoctorSchedule() { }

        public DoctorSchedule(int doctorId, Day day, TimeRange shift)
        {
            DoctorId = doctorId;
            Day = day;
            Shift = shift;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Day;
            yield return Shift;
        }
    }
}
