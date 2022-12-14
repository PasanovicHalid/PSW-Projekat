using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.ScheduledOrders
{
    public interface IScheduledOrderService : ICRUDService<Model.ScheduledOrder>
    {
        public void ReadOrederedBlood();
    }
}
