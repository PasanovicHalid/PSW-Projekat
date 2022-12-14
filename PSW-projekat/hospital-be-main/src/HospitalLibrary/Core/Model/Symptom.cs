using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Symptom : BaseModel
    {
        public String Name { get; set; }

        public Symptom() { }

        public Symptom(int id, bool deleted, String name)
        {
            Id = id;
            Deleted = deleted;
            Name = name;
        }
    }
}
