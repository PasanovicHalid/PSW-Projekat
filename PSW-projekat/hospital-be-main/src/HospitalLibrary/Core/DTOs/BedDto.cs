using HospitalLibrary.Core.Model.Enums;

namespace HospitalLibrary.Core.DTOs
{
    public class BedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BedState BedState { get; set; }
        public virtual PatientDto PatientDto { get; set; }
        public int Quantity { get; set; }
        public BedDto() { }
        public BedDto(int id, string name, BedState bedState, PatientDto patientDto, int quantity)
        {
            Id = id;
            Name = name;
            BedState = bedState;
            PatientDto = patientDto;
            Quantity = quantity;
        }
    }
}
