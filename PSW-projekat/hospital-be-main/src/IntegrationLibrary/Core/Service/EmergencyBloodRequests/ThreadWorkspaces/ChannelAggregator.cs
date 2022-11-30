using Grpc.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.EmergencyBloodRequests.ThreadWorkspaces
{
    public class ChannelAggregator
    {
        private Dictionary<string, ChannelWithUsage> _bloodBankChannels;
        private object _key;

        public ChannelAggregator()
        {
            _bloodBankChannels = new Dictionary<string, ChannelWithUsage>();
            _key = new object();
        }

        public bool CheckIfChannelExists(string channelKey)
        {
            lock(_key)
            {
                return _bloodBankChannels.ContainsKey(channelKey);
            }
        }

        public Channel AddChannel(string channelKey, Channel channel)
        {
            lock (_key)
            {
                if (CheckIfChannelExists(channelKey))
                {
                    channel?.ShutdownAsync();
                    throw new Exception("Channel already exists");
                }
                else
                {
                    _bloodBankChannels.Add(channelKey, new ChannelWithUsage(channel));
                    return channel;
                }
            }
        }

        public Channel IncreaseUsageAndGetChannel(string channelKey)
        {
            lock (_key)
            {
                _bloodBankChannels[channelKey].UsageCount++;
                return _bloodBankChannels[channelKey].Channel;
            }
        }

        public void DecreaseChannelUsage(string channelKey)
        {
            lock (_key)
            {
                int usage = _bloodBankChannels[channelKey].UsageCount--;
                if (usage <= 0)
                {
                    _bloodBankChannels.Remove(channelKey);
                }
            }
        }
    }
}
