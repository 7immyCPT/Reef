using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reef.Models
{
    public class ChannelModels
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChannelId { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Value { get; set; }
        public Nullable<bool> Default_Value { get; set; }

        public virtual ICollection<RelayChannelModels> RelayChannel { get; set; }
    }
}