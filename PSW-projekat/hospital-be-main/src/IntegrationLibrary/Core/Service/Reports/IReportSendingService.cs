using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Reports
{
    public interface IReportSendingService
    {
        bool ReportShouldBeSent();
        int GetDaysSpanTillToday(DateTime date);
        Task GeneratePDFs();

    }
}
