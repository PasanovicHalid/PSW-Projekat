using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HospitalDbContext _context;

        public UserRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public IEnumerable<User> GetAllDoctors()
        {
            return _context.User.Where(x => x.Role == Role.doctor);
        }

        public IEnumerable<User> GetAllPatients()
        {
            return _context.User.Where(x => x.Role == Role.patient);
        }

        public User GetById(int id)
        {
            return _context.User.Find(id);
        }

        public User RegisterUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
