using IntegrationLibrary.Settings;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.Repository.ScheduledOrder
{
    public class ScheduledOrderRepository : ISheduledOrderRepository
    {
        private readonly IntegrationDbContext _context;
        public ScheduledOrderRepository() { }
        public ScheduledOrderRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public void Create(Model.ScheduledOrder entity)
        {
            //check if this should be in service
            //delete old order for given blood bank
            //Delete(GetByBloodBankEmail(entity.BankEmail));
            //save new order
            _context.ScheduledOrders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Model.ScheduledOrder entity)
        {
            _context.ScheduledOrders.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Model.ScheduledOrder> GetAll()
        {
            return _context.ScheduledOrders.ToList();
        }

        public Model.ScheduledOrder GetById(int id)
        {
            return _context.ScheduledOrders.Find(id);
        }
        public Model.ScheduledOrder GetByBloodBankEmail(string email)
        {
            return (from scheduledOrders in _context.ScheduledOrders
                    where scheduledOrders.BankEmail == email
                    select scheduledOrders).FirstOrDefault();
        }

        public void Update(Model.ScheduledOrder entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
