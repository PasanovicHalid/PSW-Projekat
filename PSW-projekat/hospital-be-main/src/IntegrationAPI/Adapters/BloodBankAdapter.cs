using AutoMapper;
using IntegrationAPI.DTO;
using IntegrationLibrary.Core.Model;

namespace IntegrationAPI.Adapters
{
    public class BloodBankAdapter : Profile
    {
        public BloodBankAdapter() 
        {
            CreateMap<BloodBank, BloodBankDTO>().ReverseMap();
            CreateMap<BloodBank, BloodBankDTO>();
            CreateMap<BloodBankCreationDTO, BloodBank>();
        }
    }
}
