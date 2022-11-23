using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IBloodService : IService<Blood>
    {
        public void updateQuantityBlood(int bloodId, int quantity, Blood blood);

    }
}
