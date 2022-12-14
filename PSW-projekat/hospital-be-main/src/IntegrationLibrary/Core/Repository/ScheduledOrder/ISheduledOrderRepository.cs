using IntegrationLibrary.Core.Repository.CRUD;

namespace IntegrationLibrary.Core.Repository.ScheduledOrder
{
    public interface ISheduledOrderRepository : ICRUDRepository<Model.ScheduledOrder>
    {
        public Model.ScheduledOrder GetByBloodBankEmail(string email);
    }
}
