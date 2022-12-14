using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    public class TherapyRepository : ITherapyRepository
    {
        private readonly HospitalDbContext _context;

        public TherapyRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(Therapy therapy)
        {
            _context.Therapys.Add(therapy);
            _context.SaveChanges();
        }

        public void Delete(Therapy entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetAll()
        {
            throw new NotImplementedException();
        }

        public Therapy GetById(int id)
        {
            return _context.Therapys.Find(id);
        }

        public void Update(Therapy entity)
        {
            throw new NotImplementedException();
        }
    }
}
