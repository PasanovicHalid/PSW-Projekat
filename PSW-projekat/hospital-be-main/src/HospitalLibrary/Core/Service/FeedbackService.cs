using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class FeedbackService : IService<Feedback>
    {
        private readonly IRepository<Feedback> _feedbackRepository;

        public FeedbackService(IRepository<Feedback> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public void Create(Feedback entity)
        {
            _feedbackRepository.Create(entity);
        }

        public void Delete(Feedback entity)
        {
            _feedbackRepository.Delete(entity);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public Feedback GetById(int id)
        {
            return _feedbackRepository.GetById(id);
        }

        public void Update(Feedback entity)
        {
            _feedbackRepository.Update(entity);
        }
    }
}
