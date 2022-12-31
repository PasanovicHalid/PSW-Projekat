using HospitalLibrary.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.Tender
{
    public class Bid : ValueObject
    {
        private DateTime _deliveryDate;
        private long _price;
        private int _bloodBankId;
        private BidStatus _status = BidStatus.WAITING;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTime DeliveryDate
        {
            get => _deliveryDate;
            private set
            {
                if (value.Equals(null))
                    throw new ArgumentException("Delivery date is invalid");
                _deliveryDate = value;
            }
        }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public long Price
        {
            get => _price;
            private set
            {
                if (value.Equals(null))
                    throw new ArgumentException("Price is invalid");
                _price = value;
            }
        }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public int BloodBankId
        {
            get => _bloodBankId;
            private set
            {
                if (value.Equals(null))
                    throw new ArgumentException("Blood Bank ID is invalid");
                _bloodBankId = value;
            }
        }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public BidStatus Status
        {
            get => _status;
            private set
            {
                if(value.Equals(null))
                    throw new ArgumentException("Status is invalid");
                _status = value;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BloodBankId;
            yield return Price;
            yield return Status;
            yield return DeliveryDate;
        }

        public Bid() { }

        public Bid(DateTime deliveryDate, long price, int bloodBankID, BidStatus status)
        {
            DeliveryDate = deliveryDate;
            Price = price;
            BloodBankId = bloodBankID;
            Status = status;
        }

        public Bid(DateTime deliveryDate, long price, int bloodBankID)
        {
            DeliveryDate = deliveryDate;
            Price = price;
            BloodBankId = bloodBankID;
        }

        public void SetAsWinningBid()
        {
            Status = BidStatus.WIN;
        }

        public void SetAsLostBid()
        {
            Status = BidStatus.LOST;
        }

        public bool IsWinningBid()
        {
            return Status == BidStatus.WIN;
        }
    }
}
