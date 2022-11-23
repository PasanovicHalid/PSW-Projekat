using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Therapy: BaseModel
    {
        public virtual Medicine Medicine { get; set; }
        public virtual Blood Blood { get; set; }
        public int QuantitytMedicine { get; set; }
        public int QuantityBlood { get; set; }

        public Therapy() { }
        public Therapy(Medicine medicine, Blood blood, int quantitytMedicine, int quantityBlood)
        {
            Medicine = medicine;
            Blood = blood;
            QuantitytMedicine = quantitytMedicine;
            QuantityBlood = quantityBlood;
        }
    }
}
