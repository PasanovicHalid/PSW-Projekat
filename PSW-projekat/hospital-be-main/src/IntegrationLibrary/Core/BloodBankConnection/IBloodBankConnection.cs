using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.BloodBankConnection
{
    public interface IBloodBankConnection
    {
        Boolean SendBloodRequest(BloodBank bank, String bloodType, int quantity);
    }
}
