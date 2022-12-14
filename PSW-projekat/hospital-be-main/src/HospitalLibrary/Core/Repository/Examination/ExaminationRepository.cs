using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Repository
{
    public class ExaminationRepository : IExaminationRepository
    {

        private readonly HospitalDbContext _context;
        public ExaminationRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(Examination examination)
        {
            _context.Examinations.Add(examination);
            _context.SaveChanges();
        }

        public void Delete(Examination entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Examination> GetAll()
        {
            return _context.Examinations.ToList();
        }

        public Examination GetById(int id)
        {
            return _context.Examinations.Find(id);
        }

        public void Update(Examination entity)
        {
            throw new NotImplementedException();
        }
    }
}
