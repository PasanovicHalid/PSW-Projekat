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
    public class MedicineRepository : IMedicineRepository
    {
        private readonly HospitalDbContext _context;

        public MedicineRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _context.Medicines.ToList();
        }

        public Medicine GetById(int id)
        {
            return _context.Medicines.Find(id);
        }

        public void Update(Medicine medicine)
        {
            _context.Entry(medicine).State = EntityState.Modified;

            try
            {
                _context.Update(medicine);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
