using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository.BloodBanks
{
    public interface IBloodBankRepository : ICRUDRepository<BloodBank>
    {
        bool CheckIfAPIKeyExists(string apiKey);

        bool CheckIfAPIKeyIsUpdatable(BloodBank bank);

        bool CheckIfEmailExists(Email email);

        bool CheckIfEmailIsUpdatable(BloodBank bank);

        bool CheckIfPasswordResetKeyExists(string passwordResetKey);

        bool CheckIfPasswordResetKeyIsUpdatable(BloodBank bank);

        BloodBank GetBloodBankFromPasswordResetKey(string passwordResetKey);
        BloodBank getByEmail(string email);
    }
}
