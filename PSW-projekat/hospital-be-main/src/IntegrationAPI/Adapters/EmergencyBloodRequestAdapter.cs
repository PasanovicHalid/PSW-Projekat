using AutoMapper;
using IntegrationAPI.DTO;
using IntegrationLibrary.Core.Model;

namespace IntegrationAPI.Adapters
{
    public class EmergencyBloodRequestAdapter : Profile
    {
        public EmergencyBloodRequestAdapter()
        {
            CreateMap<EmergencyBloodRequestDTO, EmergencyBloodRequest>().ReverseMap();
            CreateMap<EmergencyBloodRequestDTO, EmergencyBloodRequest>();
        }
    }
}
