﻿using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class BedService : IBedService
    {
        private readonly IBedRepository _bedRepository;

        public BedService(IBedRepository bedRepository)
        {
            _bedRepository = bedRepository;
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
            throw new NotImplementedException();
        }

        public Bed GetById(int id)
        {
            return _bedRepository.GetById(id);
        }

        public void Update(Bed bed)
        {

            bed.Deleted = false;
            _bedRepository.Update(bed);

        }
    }
}
