using HospitalLibrary.Core.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace HospitalLibrary.Core.Model
{
    [Owned]
    public class DoctorSchedule : ValueObject
    {
        public Day Day { get; set; }
        public TimeRange Shift { get; set; }

        public DoctorSchedule() { }

        public DoctorSchedule(Day day, TimeRange shift)
        {
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
