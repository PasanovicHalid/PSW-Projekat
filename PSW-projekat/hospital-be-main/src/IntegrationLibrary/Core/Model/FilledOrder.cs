using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class FilledOrder
    {
        private bool _isSent { get; set; }
        private string _bankEmail { get;  set;}
        private int _aPlus { get; set; }
        private int _bPlus { get; set; }
        //ostale krvne grupe

        public FilledOrder()
        {

        }
        public FilledOrder(bool isSent, string bankEmail, int aPlus, int bPlus)
        {
            this._isSent = isSent;
            _bankEmail = bankEmail;
            _aPlus = aPlus;
            _bPlus = bPlus;
        }
        public bool IsSent { get => _isSent; set => _isSent = value; }
        public string BankEmail { get => _bankEmail; set => _bankEmail = value; }
        public int APlus { get => _aPlus; set => _aPlus = value; }
        public int BPlus { get => _bPlus; set => _bPlus = value; }
    }
}
