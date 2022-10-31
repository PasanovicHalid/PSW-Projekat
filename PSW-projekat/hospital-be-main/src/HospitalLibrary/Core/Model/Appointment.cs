using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Appointment: BaseModel
    {
        public virtual User Patient { get; set; }
        public virtual User Doctor { get; set; }
        public DateTime DateTime { get; set; }
      }
}
