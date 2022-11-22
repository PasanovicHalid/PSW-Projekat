using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Repository
{
    public class BedRepository : IBedRepository
    {
        private readonly HospitalDbContext _context;

        public BedRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(Bed entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Bed entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bed> GetAll()
        {
            return _context.Beds.ToList();
        }

        public Bed GetById(int id)
        {
            return _context.Beds.Find(id);
        }

        public void Update(Bed bed)
        {
            _context.Entry(bed).State = EntityState.Modified;

            try
            {
                _context.Update(bed);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
