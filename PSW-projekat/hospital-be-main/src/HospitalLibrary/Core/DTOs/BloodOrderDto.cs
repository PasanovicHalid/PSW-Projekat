using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTOs
{
    public class BloodOrderDto
    {
        public string BankEmail { get; set; }
        public bool IsSent { get; set; }
        public int APlus { get; set; }
        public int BPlus { get; set; }

        public BloodOrderDto() { }
        public BloodOrderDto(string bankEmail, bool isSent, int aPlus, int bPlus)
        {
            BankEmail = bankEmail;
            IsSent = isSent;
            APlus = aPlus;
            BPlus = bPlus;
        }
    }
}
