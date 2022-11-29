using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.ScheduledOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.ScheduledOrders
{
    public class ScheduledOrderService : IScheduledOrderService
    {
        private readonly ISheduledOrderRepository _sheduledOrderRepository;
        public ScheduledOrderService(ISheduledOrderRepository sheduledOrderRepository)
        {
            _sheduledOrderRepository = sheduledOrderRepository;
        }

        public void Create(ScheduledOrder entity)
        {
            try
            {
                //_sheduledOrderRepository.Delete(_sheduledOrderRepository.GetByBloodBankEmail(entity.BankEmail));
                _sheduledOrderRepository.Create(entity);
            }
            catch
            {
                throw new Exception("Error when creating a scheduled order");
            }
        }

        public void Delete(ScheduledOrder entity)
        {
            _sheduledOrderRepository.Delete(entity);
        }

        public IEnumerable<ScheduledOrder> GetAll()
        {
            return _sheduledOrderRepository.GetAll();
        }

        public ScheduledOrder GetById(int id)
        {
            return _sheduledOrderRepository.GetById(id);
        }

        public void Update(ScheduledOrder entity)
        {
            _sheduledOrderRepository.Update(entity);
        }
    }
}
