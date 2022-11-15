using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Reports
{
    public class ReportSettingsService : IReportSettingsService
    {
        private readonly IReportSettingsRepository _reportSettingsRepository;

        public ReportSettingsService(IReportSettingsRepository reportSettingsRepository)
        {
            _reportSettingsRepository = reportSettingsRepository;
        }

        public void Create(ReportSettings entity)
        {
            try
            {
                _reportSettingsRepository.Create(entity);
            }
            catch
            {

            }
        }

        public void Delete(ReportSettings entity)
        {
            try
            {
                _reportSettingsRepository.Delete(entity);
            }
            catch
            {

            }
        }

        public IEnumerable<ReportSettings> GetAll()
        {
            return _reportSettingsRepository.GetAll();
        }

        public ReportSettings GetById(int id)
        {
            return _reportSettingsRepository.GetById(id);
        }

        public ReportSettings GetFirst()
        {
            return _reportSettingsRepository.GetFirst();
        }

        public void Update(ReportSettings entity)
        {
            try
            {
                _reportSettingsRepository.Update(entity);
            }
            catch
            {

            }
        }

        public bool ReportShouldBeSent()
        {
            ReportSettings setting = GetFirst();
            if (setting.DeliveryYears > 0 && (GetDaysSpanTillToday(setting.StartDeliveryDate) >= setting.DeliveryYears*365)) {
                
                return true;
            }else if (setting.DeliveryMonths > 0 && (GetDaysSpanTillToday(setting.StartDeliveryDate) >= setting.DeliveryMonths * 30))
            {
                return true;
            }
            else if(setting.DeliveryDays > 0 && (GetDaysSpanTillToday(setting.StartDeliveryDate) >= setting.DeliveryDays))
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
    }
}
