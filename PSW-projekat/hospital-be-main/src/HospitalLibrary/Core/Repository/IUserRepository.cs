using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllDoctors();
        IEnumerable<User> GetAllPatients();
        User RegisterUser(User user);
    }
}
