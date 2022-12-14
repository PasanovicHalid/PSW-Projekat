using System.Collections.Generic;

namespace HospitalLibrary.Core.Model
{
    public class HistoryTreatment: BaseModel
    {
        List<Treatment> Treatments { get; set; }
    }
}
