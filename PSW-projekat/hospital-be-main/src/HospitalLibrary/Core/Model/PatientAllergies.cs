using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class PatientAllergies : BaseModel
    {
        public int PatientId { get; set; }
        public int AllergyId { get; set; }
    }
}
