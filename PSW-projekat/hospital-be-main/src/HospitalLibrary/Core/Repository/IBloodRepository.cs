using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IBloodRepository : IRepository<Blood>
    {   
        void ReduceBloodCount(Blood blood, int id);
    }
}
