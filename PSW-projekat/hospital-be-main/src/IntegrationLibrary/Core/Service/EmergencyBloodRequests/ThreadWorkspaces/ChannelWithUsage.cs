using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.EmergencyBloodRequests.ThreadWorkspaces
{
    public class ChannelWithUsage
    {
        private Channel _channel;
        private int _usageCount;

        public ChannelWithUsage(Channel channel)
        {
            _channel = channel;
            _usageCount = 1;
        }

        public Channel Channel { get => _channel;}
        public int UsageCount { get => _usageCount; set => _usageCount = value; }
    }
}
