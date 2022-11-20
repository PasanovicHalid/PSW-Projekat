using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model.Enums;

namespace HospitalLibrary.Core.Model
{
    public class Equipment: BaseModel
    {
        public virtual Medicine Medicine { get; set; }
        public virtual Bed Bed { get; set; }
        public virtual Blood Blood { get; set; }

    }
}
