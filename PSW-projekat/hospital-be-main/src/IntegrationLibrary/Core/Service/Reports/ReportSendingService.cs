using IntegrationLibrary.Core.BloodBankConnection;
using IntegrationLibrary.Core.Service.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Reports
{
    public class ReportSendingService : IReportSendingService
    {
        private readonly IBloodBankConnection _bloodBankConnection;
        private readonly BloodReportPDFGenerator bloodReportPDFGenerator = new BloodReportPDFGenerator();

        public ReportSendingService(IBloodBankConnection bloodBankConnection)
        {
            _bloodBankConnection = bloodBankConnection;
        }
        public async Task GeneratePDFs()
        {
            throw new NotImplementedException();
        }
    }
}
