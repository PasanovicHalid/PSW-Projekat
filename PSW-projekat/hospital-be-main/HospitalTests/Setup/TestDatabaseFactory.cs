using HospitalAPI;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace HospitalTests.Setup
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<HospitalDbContext>();

                InitializeDatabase(db);
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<HospitalDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<HospitalDbContext>(opt => opt.UseSqlServer(CreateConnectionStringForTest()));
            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Server=.;Database=HospitaTestlDb;TrustServerCertificate=False;Trusted_Connection=True";
        }

        private static void InitializeDatabase(HospitalDbContext context)
        {
            context.Database.EnsureCreated();

            /*
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodBanks\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"ReportSettings\";");
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
            */
            context.SaveChanges();
        }
    }
}
