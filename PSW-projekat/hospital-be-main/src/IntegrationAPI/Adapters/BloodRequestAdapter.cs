using IntegrationAPI.DTO;
using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class BloodRequestAdapter
    {
        public static BloodRequest FromDTO(BloodRequestDTO entity)
        {
            return new BloodRequest()
            {
              
            };
        }

        public static BloodRequestDTO ToDTO(BloodRequest entity)
        {
            return new BloodRequestDTO()
            {
              
            };
        }
    }
}
