﻿using IntegrationAPI;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.Tender;
using IntegrationLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace IntegrationAPITests.Setup
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<IntegrationDbContext>();

                InitializeDatabase(db);
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<IntegrationDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<IntegrationDbContext>(opt => opt.UseSqlServer(CreateConnectionStringForTest()));
            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Server=.;Database=IntegrationTestDb;TrustServerCertificate=False;Trusted_Connection=True";
        }

        private static void InitializeDatabase(IntegrationDbContext context)
        {
            context.Database.EnsureCreated();

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodBanks\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"ReportSettings\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodRequests\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Demands\";");
            context.Database.ExecuteSqlRaw("DELETE FROM \"Tenders\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Bids\"; ");

            
            context.Bids.Add(new Bid{
                DeliveryDate = System.DateTime.Now.AddDays(-1),
                Price = 2000,
                TenderOfBidId = 1,
                BloodBankId = 1,
                Status = BidStatus.WAITING
            });
            context.BloodBanks.Add(new BloodBank {
                Name = "asdsadsda",
                Email = "asdasd@gmail.com",
                Password = "asdsadsdadas",
                ApiKey = "sadfasdads",
                ServerAddress = "https://www.messenger.com/t/100001603572170",
                AccountStatus = AccountStatus.ACTIVE
            });
            context.BloodBanks.Add(new BloodBank {
                Name = "aa",
                Email = "asdasd@gmail.com",
                Password = "asdsadsdadas",
                ApiKey = "sadfasdads",
                ServerAddress = "https://www.messenger.com/t/100001603572170",
                AccountStatus = AccountStatus.ACTIVE
            });
            context.BloodBanks.Add(new BloodBank {
                Name = "bb",
                Email = "asdasd@gmail.com",
                Password = "asdsadsdadas",
                ApiKey = "sadfasdads",
                ServerAddress = "https://www.messenger.com/t/100001603572170",
                AccountStatus = AccountStatus.ACTIVE
            });
            context.BloodBanks.Add(new BloodBank {
                Name = "rr",
                Email = "asdasd@gmail.com",
                Password = "asdsadsdadas",
                ApiKey = "sadfasdads",
                ServerAddress = "https://www.messenger.com/t/100001603572170",
                AccountStatus = AccountStatus.ACTIVE
            });

            context.ReportSettings.Add(new ReportSettings
            {
                CalculationDays = 0,
                CalculationMonths = 1,
                CalculationYears = 0,
                DeliveryDays = 1,
                DeliveryMonths = 0,
                DeliveryYears = 0,
                StartDeliveryDate = System.DateTime.Now.AddDays(-1),
            });
            context.BloodRequests.Add(new BloodRequest
            {
                BloodBankId = 1,
                BloodQuantity = 2,
                BloodType = BloodType.ON,
                Reason = "For operation",
                RequestState = RequestState.Accepted,
                RequiredForDate = new System.DateTime(2022, 11, 15),
                DoctorId = 1

            });
            context.BloodRequests.Add(new BloodRequest
            {
                BloodBankId = 1,
                BloodQuantity = 3,
                BloodType = BloodType.OP,
                Reason = "For operation",
                RequestState = RequestState.Accepted,
                RequiredForDate = new System.DateTime(2022, 11, 15),
                DoctorId = 1

            });

            context.BloodRequests.Add(new BloodRequest
            {
                BloodQuantity = 1,
                BloodType = BloodType.BP,
                DoctorId = 4,
                Reason = "sadasddas",
                RequestState = RequestState.Pending,
                RequiredForDate = System.DateTime.MaxValue,
                Comment = ""
            });

            context.BloodRequests.Add(new BloodRequest
            {
                BloodQuantity = 5,
                BloodType = BloodType.BN,
                DoctorId = 2,
                Reason = "asdasddas",
                RequestState = RequestState.Pending,
                RequiredForDate = System.DateTime.MaxValue,
                Comment = ""
            });

            context.BloodRequests.Add(new BloodRequest
            {
                BloodQuantity = 5,
                BloodType = BloodType.BN,
                DoctorId = 1,
                Reason = "asdasddas",
                RequestState = RequestState.Accepted,
                RequiredForDate = System.DateTime.MaxValue,
                Comment = ""
            });

            context.BloodRequests.Add(new BloodRequest
            {
                BloodQuantity = 5,
                BloodType = BloodType.BN,
                DoctorId = 3,
                Reason = "asdasddas",
                RequestState = RequestState.Returned,
                RequiredForDate = System.DateTime.MaxValue,
                Comment = "asddaswreqwreqwr"
            });

            context.BloodRequests.Add(new BloodRequest
            {
                BloodQuantity = 5,
                BloodType = BloodType.ON,
                DoctorId = 2,
                Reason = "asdasddas",
                RequestState = RequestState.Declined,
                RequiredForDate = System.DateTime.MaxValue,
                Comment = ""
            });
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Newses\";");
            context.Newses.Add(new News
            {
                Status = NewsStatus.PENDING,
                Title = "Blood donation",
                Text = " Come and give me blood",
                DateTime = new DateTime(2022, 01, 01, 9, 15, 0),
                BloodBankId = 1,
            }); 

            context.SaveChanges();
        }
    }
}
