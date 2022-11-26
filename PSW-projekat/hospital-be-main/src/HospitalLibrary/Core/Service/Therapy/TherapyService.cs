using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class TherapyService : ITherapyService
    {
        private readonly ITherapyRepository _therapyRepository;

        public TherapyService(ITherapyRepository therapyRepository)
        {
            _therapyRepository = therapyRepository;

        }
        public void Create(Therapy therapy)
        {
            therapy.Deleted = false;
            _therapyRepository.Create(therapy);

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
            return _therapyRepository.GetById(id);
        }

        public void Update(Therapy entity)
        {
            throw new NotImplementedException();
        }
    }
}
