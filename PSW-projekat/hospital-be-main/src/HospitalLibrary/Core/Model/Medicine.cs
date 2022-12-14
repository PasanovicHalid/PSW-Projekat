namespace HospitalLibrary.Core.Model
{
    public class Medicine: BaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Medicine( int id, bool deleted, string name, int quantity)
        {
            Id = id;
            Deleted = deleted;
            Name = name;
            Quantity = quantity;
        }
    }
}
