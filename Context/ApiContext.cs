using InMemoryApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryApi.Context
{
    public class ApiContext : DbContext
    {

        public DbSet<Client> Clients { get; set; }
        

        public ApiContext(DbContextOptions options) : base(options) {
        }
        public ApiContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MinhaDataBase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(x => x.Id);
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                Id = 10,
                Name = "Maria",
                Email = "Maria@Gmail.com",
                Street = "Rua João Vicente",
                Number = 75,
                City = "Rio de Janeiro"
                
              
            });
            
        }
    }
}
