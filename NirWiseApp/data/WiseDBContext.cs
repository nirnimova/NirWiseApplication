using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NirWiseApp.Data
{
    public class WiseDBContext : DbContext
    {
        public WiseDBContext() : base("DefaultConnection")
        {

        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<FeeAgreement> FeeAgreements { get; set; }
    }
}