using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model.Enums;

namespace HospitalLibrary.Core.Model
{
    public class Blood: BaseModel
    {
        public BloodType BloodType { get; set; }
        public int Quantity { get; set; }

        public Blood(int id, bool deleted, BloodType bloodType, int quantity)
        {
            Id = id;
            Deleted = deleted;
            BloodType = bloodType;
            Quantity = quantity;
        }
    }
}
