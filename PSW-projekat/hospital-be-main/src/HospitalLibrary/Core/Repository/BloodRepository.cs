using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Repository
{
    public class BloodRepository : IBloodRepository
    {
        private readonly HospitalDbContext _context;

        public BloodRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(Blood entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blood entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blood> GetAll()
        {
            return _context.Bloods.ToList();
        }

        public Blood GetById(int id)
        {
            return _context.Bloods.Find(id);
        }


        public void ReduceBloodCount(Blood blood, int id)
        {
            _context.Entry(blood).State = EntityState.Modified;

            try
            {
                _context.Update(blood);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Update(Blood blood)
        {
            _context.Entry(blood).State = EntityState.Modified;

            try
            {
                _context.Update(blood);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
