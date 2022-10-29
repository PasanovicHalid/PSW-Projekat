using IntegrationLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IntegrationLibrary.Settings
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<BloodBank> BloodBanks { get; set; }

        public IntegrationDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodBank>().HasData(
                new BloodBank() { Id = 1 , Name = "asdsadsda", Email = "asdasd@gmail.com", Password = "asdsadsdadas" , ApiKey = "sadfasdads" , ServerAddress = "https://www.messenger.com/t/100001603572170", AccountStatus = AccountStatus.ACTIVE } 
            ) ;
            base.OnModelCreating(modelBuilder);
        }
    }
}
