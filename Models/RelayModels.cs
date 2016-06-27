using Reef.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reef.Models
{
    public class RelayModels
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RelayId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RelayChannelModels> RelayChannel { get; set; }
    }
}