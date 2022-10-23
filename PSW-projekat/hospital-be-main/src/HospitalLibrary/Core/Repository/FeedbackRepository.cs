using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        private readonly HospitalDbContext _context;

        public FeedbackRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(Feedback entity)
        {
            _context.Feedbacks.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Feedback entity)
        {
            _context.Feedbacks.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks.ToList();
        }

        public Feedback GetById(int id)
        {
            return _context.Feedbacks.Find(id);
        }

        public void Update(Feedback entity)
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

