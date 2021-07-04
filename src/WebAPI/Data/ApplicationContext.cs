using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(a =>
            {
                a.HasIndex(x => x.Email).IsUnique();
                a.Property(x => x.Name).IsRequired();
                a.Property(x => x.Surname).IsRequired();
                a.BaseEntityBuilder();
            });

            modelBuilder.Entity<Activity>(a =>
            {
                a.HasIndex(x => x.Name).IsUnique();
                a.BaseEntityBuilder();
            });

            modelBuilder.Entity<EmployeeActivity>(a =>
            {
                a.HasKey(x => new { x.EmployeeId, x.ActivityId });
                a.HasOne(x => x.Employee).WithMany(x => x.EmployeeActivities).HasForeignKey(x => x.EmployeeId);
                a.HasOne(x => x.Activity).WithMany(x => x.EmployeeActivities).HasForeignKey(x => x.ActivityId);
            });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<EmployeeActivity> EmployeeActivities { get; set; }
    }
}


