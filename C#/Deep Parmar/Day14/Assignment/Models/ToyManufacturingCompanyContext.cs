using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day14.Models
{
    public class ToyManufacturingCompanyContext:DbContext
    {
        public ToyManufacturingCompanyContext(DbContextOptions<ToyManufacturingCompanyContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItems>().HasKey(odr => new { odr.OrderId, odr.ToyId });

            //modelBuilder.Entity<Orders>().Property(s => s.OrderDate).HasDefaultValue(DateTime.Now);
        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerAddress> CustomerAddresses { get; set; }

        public DbSet<Plant> Plants { get; set; }

        public DbSet<Toys> Toys { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderItems> OrderItems { get; set; }
    }
}
