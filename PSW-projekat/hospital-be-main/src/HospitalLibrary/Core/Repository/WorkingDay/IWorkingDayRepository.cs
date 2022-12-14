using System.Collections.Generic;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IWorkingDayRepository : IRepository<WorkingDay>
    {
        IEnumerable<WorkingDay> GetAllWorkingDaysByUser(int personId);

    }
}
