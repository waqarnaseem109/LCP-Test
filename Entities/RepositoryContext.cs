using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            //Seed data in product folder
            modelBuilder.Entity<Client>().HasData(
                new Client { ClientId = Guid.NewGuid(), FirstName = "John",LastName="Tim",DateOfBirth= DateTime.Now,Address="TW3 5RS" },
                new Client { ClientId = Guid.NewGuid(), FirstName = "Sara", LastName = "Sara", DateOfBirth = DateTime.Now, Address = "SE2 2TR" },
                new Client { ClientId = Guid.NewGuid(), FirstName = "Peter", LastName = "Pin", DateOfBirth = DateTime.Now, Address = "RE3 8UY" });;

        }
    }
}

