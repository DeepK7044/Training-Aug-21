using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day15.Models
{
    public class EmployeeDataContext:DbContext
    {
        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(emp => emp.Status).HasDefaultValue(true);
            modelBuilder.Entity<Assignment>().Property(Assignment => Assignment.Status).HasDefaultValue(true);
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Assignment> Assignments { get; set; }
    }
}
