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
        public DbSet<ReportSettings> ReportSettings { get; set; }

        public DbSet<BloodRequest> BloodRequests { get; set; }

        public IntegrationDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodRequest>().HasData(
                new BloodRequest()
                {
                    BloodQuantity = 5,
                    BloodType = BloodType.BP,
                    DoctorId = 4,
                    Id = 1,
                    Reason = "asdasdadsadsdas",
                    RequestState = RequestState.Pending,
                    RequiredForDate = DateTime.Now
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
