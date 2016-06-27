using Reef.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reef.Models
{
    public class RelayChannelModels
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RelayChannelId { get; set; }
        public Nullable<int> RelayId { get; set; }
        public Nullable<int> ChannelId { get; set; }
        public Nullable<int> ClientId { get; set; }

        public virtual ChannelModels Channel { get; set; }
        public virtual RelayModels Relay { get; set; }
    }
}