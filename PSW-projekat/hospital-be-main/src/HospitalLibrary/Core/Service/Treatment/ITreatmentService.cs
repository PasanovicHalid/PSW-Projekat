using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface ITreatmentService : IService<Treatment>
    {
        byte[] GeneratePdf(Treatment treatment);
    }
}
