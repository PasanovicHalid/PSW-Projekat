using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetAllDoctors()
        {
            return _userRepository.GetAllDoctors();
        }

        public IEnumerable<User> GetAllPatients()
        {
            return _userRepository.GetAllPatients();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
