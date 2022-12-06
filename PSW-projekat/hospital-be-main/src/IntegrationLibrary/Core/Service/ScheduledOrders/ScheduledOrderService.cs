using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.BloodBanks;
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
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IBloodBankRepository _bloodBankRepository;
        public ScheduledOrderService(ISheduledOrderRepository sheduledOrderRepository, IRabbitMQService rabbitMQService, IBloodBankRepository bloodBankRepository)
        {
            _sheduledOrderRepository = sheduledOrderRepository;
            _rabbitMQService = rabbitMQService;
            _bloodBankRepository = bloodBankRepository;
        }

        public void Create(ScheduledOrder entity)
        {
            try
            {
                ScheduledOrder readOrder = _sheduledOrderRepository.GetByBloodBankEmail(entity.BankEmail);
                if (readOrder != null)
                {
                    _sheduledOrderRepository.Delete(readOrder);
                }
                _sheduledOrderRepository.Create(entity);
                _rabbitMQService.SendScheduledOrder(entity);
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
        public void ReadOrederedBlood()
        {
            List<FilledOrder> filledOrders = _rabbitMQService.ReciveSheduledOrders(_bloodBankRepository.GetAll().ToList());
            Console.WriteLine(filledOrders);
            //send post request to hospital api with filled orders
                //if isSent -> save sent blood to blood database
                //else -> notify menager that his order wont be delivered

        }
    }
}
