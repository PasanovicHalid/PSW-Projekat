using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class ScheduledOrder : BaseModel
    {
        private int _dayOfMonth;
        private int _aPlus;
        private int _bPlus;
        //ostale krvne grupe
        private string _bankEmail;
        private string _bankApiKey;
        private string _hospitalEmail;

        public ScheduledOrder() { }

        public int DayOfMonth { get => _dayOfMonth; set => _dayOfMonth = value; }
        public int APlus { get => _aPlus; set => _aPlus = value; }
        public int BPlus { get => _bPlus; set => _bPlus = value; }
        public string BankEmail { get => _bankEmail; set => _bankEmail = value; }
        public string BankApiKey { get => _bankApiKey; set => _bankApiKey = value; }
        public string HospitalEmail { get => _hospitalEmail; set => _hospitalEmail = value; }
    }
}
