using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface ITreatmentService : IService<Treatment>
    {
        byte[] GeneratePdf(Treatment treatment);
    }
}
