using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Reports
{
    public interface IReportSettingsService
    {
        IEnumerable<ReportSettings> GetAll();
        ReportSettings GetFirst();
        void Create(ReportSettings entity);
        void Update(ReportSettings entity);
        void Delete(ReportSettings entity);

        ReportSettings GetById(int id);
        bool ReportShouldBeSent();
        int GetDaysSpanTillToday(DateTime date);
    }
}
