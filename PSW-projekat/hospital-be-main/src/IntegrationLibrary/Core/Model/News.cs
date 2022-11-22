using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class News : BaseModel
    {
        private string _title { get; set; }
        private string _text { get; set; }
        private DateTime _dateTime { get; set; }
        private NewsStatus _status { get; set; }
        private int _bloodBankId { get; set; }
        
        public News()
        {
        }
        public News(string title, string text, DateTime dateTime, NewsStatus newsStatus, int blodBankId)
        {
            _status = newsStatus;
            _text = text;
            _title = title;
            _bloodBankId = blodBankId;
            _dateTime = dateTime;
        }

        public News(string title, string text, DateTime dateTime, int blodBankId)
        {
            _title = title;
            _text = text;
            _dateTime = dateTime;
            _status = NewsStatus.PENDING;
            _bloodBankId = blodBankId;
        }

        public string Text { get => _text; set => _text = value; }
        public string Title { get => _title; set => _title = value; }

        public NewsStatus Status { get => _status; set => _status = value; }    
        
        public DateTime DateTime { get => _dateTime; set => _dateTime = value; }

        public int BloodBankId { get => _bloodBankId; set => _bloodBankId = value; }

    }
}
