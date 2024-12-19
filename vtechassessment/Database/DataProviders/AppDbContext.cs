using Microsoft.EntityFrameworkCore;
using System;
using vtechassessment.Models;

namespace vtechassessment.Database.DataProviders
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>().HasData(
        //        new Customer { 
        //            CustomerId = Guid.NewGuid(), 
        //            Email = "test@test.com", 
        //            FirstName = "fNameTest", 
        //            MiddleName = "mNameTest",
        //            LastName = "lastNameTest", 
        //            PhoneNumber = "416-432-9987" 
        //        });

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
