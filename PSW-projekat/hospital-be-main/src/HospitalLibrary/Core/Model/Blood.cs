using HospitalLibrary.Core.Model.Enums;

namespace HospitalLibrary.Core.Model
{
    public class Blood: BaseModel
    {
        public BloodType BloodType { get; set; }
        public int Quantity { get; set; }

        public int RoomId { get; set; }

        public Blood() { }
        public Blood(int id, bool deleted, BloodType bloodType, int quantity)
        {
            Id = id;
            Deleted = deleted;
            BloodType = bloodType;
            Quantity = quantity;
        }

        public Blood(int id, BloodType bloodType, int quantity)
        {
            Deleted = false;
            BloodType = bloodType;
            Quantity = quantity;
            Id = id;
        }

    }
}
