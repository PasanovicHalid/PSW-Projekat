using IntegrationLibrary.Core.Model.Tender;
using IntegrationLibrary.Core.Service.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public interface IBidService : ICRUDService<Bid>
    {
        IEnumerable<Bid> GetByTenderId(int id);

        void SelectWinner(int id);
    }
}
