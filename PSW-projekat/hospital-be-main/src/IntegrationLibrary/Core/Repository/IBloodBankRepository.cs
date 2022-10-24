using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public interface IBloodBankRepository : ICRUDRepository<BloodBank>
    {
        bool CheckIfAPIKeyExists(string apiKey);

        bool CheckIfAPIKeyIsUpdatable(BloodBank bank);

        bool CheckIfEmailExists(string email);

        bool CheckIfEmailIsUpdatable(BloodBank bank);
    }
}
