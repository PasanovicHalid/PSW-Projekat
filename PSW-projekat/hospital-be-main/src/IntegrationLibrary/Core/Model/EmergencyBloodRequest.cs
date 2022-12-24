using IntegrationLibrary.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class EmergencyBloodRequest
    {
        public int BloodQuantity { get; set; }

        public BloodTypeProto BloodType { get; set; }

        public int BloodBankID { get; set; }
    }
}
