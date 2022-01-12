using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ARS.Models
{
    public class ContextCS : DbContext

    {
        public ContextCS() : base("cs")
        {

        }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<UserAccount> UserLogin { get; set; }
        public DbSet<AeroPlaneInfo> PlaneInfo { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }

        public System.Data.Entity.DbSet<ARS.Models.TicketReserve_tbl> TicketReserve_tbl { get; set; }
    }
}