using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodBankRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public bool CheckIfAPIKeyExists(string apiKey)
        {
            return (from banks in _context.BloodBanks
                    where banks.ApiKey == apiKey
                    select banks).Any();
        }

        public bool CheckIfAPIKeyIsUpdatable(BloodBank bank)
        {
            return (from banks in _context.BloodBanks
                    where banks.ApiKey == bank.ApiKey && banks.Id != bank.Id
                    select banks).Any();
        }

        public bool CheckIfEmailExists(string email)
        {
            return (from banks in _context.BloodBanks
                    where banks.Email == email 
                    select banks).Any();
        }

        public bool CheckIfEmailIsUpdatable(BloodBank bank)
        {
            return (from banks in _context.BloodBanks
                    where banks.Email == bank.Email && banks.Id != bank.Id
                    select banks).Any();
        }

        public void Create(BloodBank entity)
        {
            _context.BloodBanks.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(BloodBank entity)
        {
            _context.BloodBanks.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<BloodBank> GetAll()
        {
            return _context.BloodBanks.ToList();
        }

        public BloodBank GetById(int id)
        {
            return _context.BloodBanks.Find(id);
        }

        public void Update(BloodBank entity)
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
