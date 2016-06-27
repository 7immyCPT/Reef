using Reef.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Reef.DAL
{
    public class ReefKeeperDBContext : DbContext
    {
        public ReefKeeperDBContext() : base("ReefKeeperDBContext")
        {
        }
        public DbSet<RelayModels> Relay { get; set; }
        public DbSet<ChannelModels> Channel { get; set; }
        public DbSet<RelayChannelModels> RelayChannel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}