using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository.Reports
{
    public interface IReportSettingsRepository : ICRUDRepository<ReportSettings>
    {
        ReportSettings GetFirst();
    }
}
