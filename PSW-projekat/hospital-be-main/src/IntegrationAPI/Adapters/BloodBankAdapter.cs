using IntegrationAPI.DTO;
using IntegrationLibrary.Core.Model;

namespace IntegrationAPI.Adapters
{
    public class BloodBankAdapter
    {
        public static BloodBank FromDTO(BloodBankDTO entity)
        {
            return new BloodBank()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password,
                ApiKey = entity.ApiKey,
                ServerAddress = entity.ServerAddress,
            };
        }

        public static BloodBankDTO ToDTO(BloodBank entity)
        {
            return new BloodBankDTO()
            {
                Id = entity.Id,
                Name = entity.Name, 
                Email = entity.Email,
                Password = entity.Password,
                ApiKey = entity.ApiKey,
                ServerAddress = entity.ServerAddress
            };
        }
    }
}
