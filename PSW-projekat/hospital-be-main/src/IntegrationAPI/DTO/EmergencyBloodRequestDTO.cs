using IntegrationLibrary.Core.Model;

namespace IntegrationAPI.DTO
{
    public class EmergencyBloodRequestDTO
    {
        public int BloodQuantity { get; set; }

        public BloodType BloodType { get; set; }
    }
}
