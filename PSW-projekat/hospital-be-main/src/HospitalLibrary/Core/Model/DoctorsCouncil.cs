using HospitalLibrary.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class DoctorsCouncil : BaseModel
    {
        public String Topic { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        [NotMapped]
        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}
