using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Repository
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly HospitalDbContext _context;

        public TreatmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            _context.SaveChanges();
        }

        public void Delete(Treatment treatment)
        {
            _context.Treatments.Remove(treatment);
            _context.SaveChanges();
        }

        public IEnumerable<Treatment> GetAll()
        {
            return _context.Treatments.ToList();
        }

        public Treatment GetById(int id)
        {
            return _context.Treatments.Find(id);
        }

        public void Update(Treatment treatment)
        {
            _context.Entry(treatment).State = EntityState.Modified;

            try
            {
                _context.Update(treatment);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
