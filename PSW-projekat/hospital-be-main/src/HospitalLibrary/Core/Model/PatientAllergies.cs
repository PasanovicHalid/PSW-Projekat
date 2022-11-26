namespace HospitalLibrary.Core.Model
{
    public class PatientAllergies : BaseModel
    {
        public int PatientId { get; set; }
        public int AllergyId { get; set; }
    }
}
