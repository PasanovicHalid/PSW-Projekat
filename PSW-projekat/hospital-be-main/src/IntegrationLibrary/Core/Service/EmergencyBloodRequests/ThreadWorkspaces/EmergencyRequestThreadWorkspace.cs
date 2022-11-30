using Grpc.Core;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Protos.EmergencyBloodRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.EmergencyBloodRequests.ThreadWorkspaces
{
    public class EmergencyRequestThreadWorkspace
    {
        private IEnumerable<BloodBank> _bloodBanks;
        private EmergencyBloodRequest _request;
        private object _key;
        private bool _available;

        public EmergencyRequestThreadWorkspace(IEnumerable<BloodBank> bloodBanks, EmergencyBloodRequest request)
        {
            _bloodBanks = bloodBanks;
            _key = new object();
            _available = false;
            _request = request;
        }

        public bool Available
        {
            get
            {
                lock (Key)
                {
                    return _available;
                }
            }

            set
            {
                lock (Key)
                {
                    _available = value;
                }
            }
        }
        public object Key { get => _key; }
        public IEnumerable<BloodBank> BloodBanks { get => _bloodBanks; set => _bloodBanks = value; }
        public EmergencyBloodRequest Request { get => _request; set => _request = value; }
        public static ChannelAggregator ChannelAggregator { get; set; } = new();

        public void StartRequestingEmergencyBlood()
        {
            foreach (BloodBank bloodBank in BloodBanks)
            {
                if (Available) break;
                Thread checker = new Thread(() => RequestEmergencyBlood(bloodBank.ServerAddress));
                checker.Start();
            }
        }


        private void RequestEmergencyBlood(string bloodBankServerAddress)
        {
            try
            {
                EmergencyRequestGrpcService.EmergencyRequestGrpcServiceClient client =
                new EmergencyRequestGrpcService.EmergencyRequestGrpcServiceClient(
                    CreateChannelForBankConnection(bloodBankServerAddress));
                CheckResponse checkResponse = client.CheckIfBloodIsAvailable(new CheckRequest(), deadline: DateTime.Now.AddSeconds(5));

                if (checkResponse.Availability == BloodAvailability.Available)
                {
                    RequestBlood(client);
                }
            } 
            finally
            {
                ChannelAggregator.DecreaseChannelUsage(bloodBankServerAddress);
            }
        }

        private void RequestBlood(EmergencyRequestGrpcService.EmergencyRequestGrpcServiceClient client)
        {
            if (!Available)
            {
                lock (Key)
                {
                    if (!Available)
                    {
                        Available = true;
                        EmergencyResponse emergencyResponse = client.RequestBlood(new EmergencyRequest(), deadline: DateTime.Now.AddSeconds(5));
                    }
                }
            }
        }

        private Channel CreateChannelForBankConnection(string bloodBankServerAddress)
        {
            if (ChannelAggregator.CheckIfChannelExists(bloodBankServerAddress))
            {
                return ChannelAggregator.IncreaseUsageAndGetChannel(bloodBankServerAddress);
            }
            else
            {
                try
                {
                    return ChannelAggregator.AddChannel(bloodBankServerAddress,
                        new Channel(bloodBankServerAddress, ChannelCredentials.SecureSsl));
                }
                catch
                {
                    return ChannelAggregator.IncreaseUsageAndGetChannel(bloodBankServerAddress);
                }
            }
        }
    }
}
