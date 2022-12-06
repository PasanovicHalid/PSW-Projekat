using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.BloodBanks;
using IntegrationLibrary.Core.Repository.ScheduledOrder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.ScheduledOrders
{
    public class ScheduledOrderService : IScheduledOrderService
    {
        private readonly ISheduledOrderRepository _sheduledOrderRepository;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IBloodBankRepository _bloodBankRepository;
        private static readonly HttpClient client = new HttpClient();
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
            Console.WriteLine("saved orders:");
            foreach (FilledOrder filledOrder in filledOrders)
            {
                Console.WriteLine("in loop");
                Console.WriteLine(filledOrder.BankEmail);
                Console.WriteLine(filledOrder.APlus);
            }
            //send post request to hospital api with filled orders
            //if isSent -> save sent blood to blood database
            //else -> notify menager that his order wont be delivered
            sendReq(filledOrders);
            


        }
        private async void sendReq(List<FilledOrder> filledOrders)
        {
            var values = new Dictionary<string, string>
              {
                  { "filledOrders", JsonConvert.SerializeObject(filledOrders)}
              };
            Console.WriteLine("values: ");
            Console.WriteLine(values);
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://localhost:16177/api/Blood/takeOrder", content);
            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}
