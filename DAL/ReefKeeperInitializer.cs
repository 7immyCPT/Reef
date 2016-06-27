using Reef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reef.DAL
{
    public class ReefKeeperInitializer : System.Data.Entity.DropCreateDatabaseAlways<ReefKeeperDBContext>
    {
        protected override void Seed(ReefKeeperDBContext context)
        {
            var relay = new List<RelayModels>
            {
                new RelayModels { RelayId = 1, Description= "Relay1" }
            };

            relay.ForEach(s => context.Relay.Add(s));
            context.SaveChanges();

            var channel = new List<ChannelModels>
            {
                new ChannelModels { ChannelId = 1, Description= "Channel1", Value = true, Default_Value = true },
                new ChannelModels { ChannelId = 2, Description= "Channel2", Value = true, Default_Value = true },
                new ChannelModels { ChannelId = 3, Description= "Channel3", Value = true, Default_Value = true },
                new ChannelModels { ChannelId = 4, Description= "Channel4", Value = true, Default_Value = true },
                new ChannelModels { ChannelId = 5, Description= "Channel5", Value = true, Default_Value = true },
                new ChannelModels { ChannelId = 6, Description= "Channel6", Value = true, Default_Value = true },
                new ChannelModels { ChannelId = 7, Description= "Channel7", Value = true, Default_Value = true },
                new ChannelModels { ChannelId = 8, Description= "Channel8", Value = true, Default_Value = true }
            };

            channel.ForEach(s => context.Channel.Add(s));
            context.SaveChanges();
            var relaychannel = new List<RelayChannelModels>
            {
                new RelayChannelModels { RelayChannelId = 1, RelayId = 1, ChannelId = 1 },
                new RelayChannelModels { RelayChannelId = 2, RelayId = 1, ChannelId = 2 },
                new RelayChannelModels { RelayChannelId = 3, RelayId = 1, ChannelId = 3 },
                new RelayChannelModels { RelayChannelId = 4, RelayId = 1, ChannelId = 4 },
                new RelayChannelModels { RelayChannelId = 5, RelayId = 1, ChannelId = 5 },
                new RelayChannelModels { RelayChannelId = 6, RelayId = 1, ChannelId = 6 },
                new RelayChannelModels { RelayChannelId = 7, RelayId = 1, ChannelId = 7 },
                new RelayChannelModels { RelayChannelId = 8, RelayId = 1, ChannelId = 8 },
            };
            relaychannel.ForEach(s => context.RelayChannel.Add(s));
            context.SaveChanges();
        }
    }
}