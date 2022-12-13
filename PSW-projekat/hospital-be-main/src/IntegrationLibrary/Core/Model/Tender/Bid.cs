using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.Tender
{
    public class Bid : BaseModel
    {
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public long Price { get; set; }
        [Required]
        public  int TenderOfBidId { get; set; }
        [Required]
        public int BloodBankId { get; set; }
        public BidStatus Status { get; set; }

        public Bid() { }
        public Bid(DateTime dateTime,long price, int tenderId, int bloodBankId) 
        {
            Status = BidStatus.WAITING;
            DeliveryDate = dateTime;
            Price = price;
            TenderOfBidId = tenderId;
            BloodBankId = bloodBankId;
        }
    }
}
