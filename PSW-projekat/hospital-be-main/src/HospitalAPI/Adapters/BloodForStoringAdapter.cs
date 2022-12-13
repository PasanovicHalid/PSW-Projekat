using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Adapters
{
    public class BloodForStoringAdapter
    {
        public static Blood FromDTO(BloodForStoringDTO entity)
        {
            return new Blood()
            {
                Id = entity.Id,
                Quantity = entity.Quantity,
                BloodType = entity.BloodType,
            };
        }

        public static BloodForStoringDTO ToDTO(Blood entity)
        {
            return new BloodForStoringDTO()
            {
               Id = entity.Id,
               Quantity = entity.Quantity,
               BloodType = entity.BloodType,
            };
        }
    }
}
