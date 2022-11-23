using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IMedicineService : IService<Medicine>
    {
        public void updateQuantityMedicine(int medicineId, int quantity, Medicine medicine);

    }
}
