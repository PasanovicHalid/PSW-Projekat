using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class News : BaseModel
    {
        private string _name;
        private DateTime _dateTime;
        private int _bloodBankId;
        private NewsStatus _status;

        public News()
        {
        }
        public string Name { get => _name; set => _name = value; }
        
        public DateTime DateTime { get => _dateTime; set => _dateTime = value; }

        public int BloodBankId { get => _bloodBankId; set => _bloodBankId = value; }

        public NewsStatus Status { get => _status; set => _status = value; }

    }
}
