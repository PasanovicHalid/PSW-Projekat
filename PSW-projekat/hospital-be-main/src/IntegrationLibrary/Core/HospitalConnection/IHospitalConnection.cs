using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.HospitalConnection
{
    public interface IHospitalConnection
    {
        bool StoreBlood(Blood blood);
    }
}
