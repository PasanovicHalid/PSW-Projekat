using IntegrationLibrary.Core.BloodBankConnection;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.BloodBanks;
using IntegrationLibrary.Core.Service.BloodRequests;
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
        private readonly IReportSettingsService _reportSettingsService;
        private readonly IBloodBankService _bloodBankService;
        private readonly IBloodRequestService _bloodRequestService;
        private readonly BloodReportPDFGenerator bloodReportPDFGenerator = new BloodReportPDFGenerator();

        public ReportSendingService(IBloodBankConnection bloodBankConnection, IReportSettingsService reportSettingsService,
                                    IBloodBankService bloodBankService, IBloodRequestService bloodRequestService)
        {
            _bloodBankConnection = bloodBankConnection;
            _reportSettingsService = reportSettingsService;
            _bloodBankService = bloodBankService;
            _bloodRequestService = bloodRequestService;
        }

        public bool ReportShouldBeSent()
        {
            ReportSettings setting = _reportSettingsService.GetFirst();
            if (setting.DeliveryYears > 0 && (GetDaysSpanTillToday(setting.StartDeliveryDate) >= setting.DeliveryYears * 365))
            {

                return true;
            }
            else if (setting.DeliveryMonths > 0 && (GetDaysSpanTillToday(setting.StartDeliveryDate) >= setting.DeliveryMonths * 30))
            {
                return true;
            }
            else if (setting.DeliveryDays > 0 && (GetDaysSpanTillToday(setting.StartDeliveryDate) >= setting.DeliveryDays))
            {
                return true;
            }
            return false;

        }
        public int GetDaysSpanTillToday(DateTime dateForChecking)
        {
            DateTime today = DateTime.Now;
            return (int)today.Subtract(dateForChecking).TotalDays;
        }
        public async Task GeneratePDFs()
        {
            List<BloodBank> banks = (List<BloodBank>)_bloodBankService.GetAll();
            foreach (BloodBank bank in banks)
            {
                List<BloodRequest> acceptedRequests = (List<BloodRequest>)_bloodRequestService.GetAcceptedRequests(bank.Id);
                await bloodReportPDFGenerator.CreatePDF(acceptedRequests, bank);
            }
        }
    }
}
