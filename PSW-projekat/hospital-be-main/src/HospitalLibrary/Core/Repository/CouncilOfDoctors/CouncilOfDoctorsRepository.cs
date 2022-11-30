using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.CouncilOfDoctors
{
    public class CouncilOfDoctorsRepository : ICouncilOfDoctorsRepository
    {
        private readonly HospitalDbContext _context;

        public CouncilOfDoctorsRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(DoctorsCouncil entity)
        {
            _context.DoctorsCouncils.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(DoctorsCouncil entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorsCouncil> GetAll()
        {
            throw new NotImplementedException();
        }

        public DoctorsCouncil GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DoctorsCouncil entity)
        {
            throw new NotImplementedException();
        }
    }
}
