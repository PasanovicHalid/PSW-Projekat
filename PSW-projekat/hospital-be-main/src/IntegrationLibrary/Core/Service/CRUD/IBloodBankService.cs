using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.CRUD
{
    public interface IBloodBankService : ICRUDService<BloodBank>
    {
        Boolean SendBloodRequest(int bloodBankID, String BloodType, int quantity);
    }
}
