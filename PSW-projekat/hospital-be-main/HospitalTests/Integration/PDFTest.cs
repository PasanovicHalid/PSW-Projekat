using System;
using System.IO;
using HospitalAPI;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace HospitalTests.Integration
{
    public class PDFTest : BaseIntegrationTest
    {
        public PDFTest(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }


        private static TreatmentService SetupSettingsService(IServiceScope scope)
        {
            var mockConnection = new Mock<ITreatmentRepository>();
            return new TreatmentService(mockConnection.Object); 
            //return new TreatmentService(mockConnection.Object, scope.ServiceProvider.GetRequiredService<ITreatmentService>());

        }

        /*
        public void Create_PDF_report()
        {
            using var scope = Factory.Services.CreateScope();
            var generator = SetupSettingsService(scope);

            var result = generator.GeneratePdf(Treatment treatment);
            String path = fali;
            Assert.True(File.Exists(path));
        }
        */

    }

}
