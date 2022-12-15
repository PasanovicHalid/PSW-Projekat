using System;
using System.Threading;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using Xunit;

namespace HospitalTests.E2E_tests
{
    public class SchedulingAppointmentTest : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.LoginPage loginPage;
        private Pages.SchedulingAppointmentPage schedulingAppointmentPage;

        public SchedulingAppointmentTest()
        {
            // options for launching Google Chrome
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            driver = new ChromeDriver(options);

            loginPage = new Pages.LoginPage(driver);
            loginPage.Navigate();
            loginPage.EnsurePageIsDisplayed();
            Thread.Sleep(500);
            loginPage.InsertUsername("marko");
            Thread.Sleep(500);
            loginPage.InsertPassword("123");
            Thread.Sleep(500);
            loginPage.SubmitForm();
            Thread.Sleep(500);
            loginPage.ErrorDivDisplayed().ShouldBe(false);

            schedulingAppointmentPage = new Pages.SchedulingAppointmentPage(driver);
            schedulingAppointmentPage.Navigate();
            Thread.Sleep(2000);

            Assert.True(schedulingAppointmentPage.PatientSelectButtonDisplayedOnScreen());          
            Assert.True(schedulingAppointmentPage.DateTimeFieldDisplayedOnScreen());
            
        }
        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        /*
        [Fact]
        public void TestInvalidDateTime()
        {
            bool pom = true;
            schedulingAppointmentPage.PatientSelectButtonDisplayed();  //insert patient except date time
            schedulingAppointmentPage.SubmitForm();

            schedulingAppointmentPage.WaitForAlertDialog();         // wait for alert dialog
            Assert.Equal(Pages.SchedulingAppointmentPage.InvalidDateTimeMessage, schedulingAppointmentPage.GetDialogMessage());     // check if alert message expected
            schedulingAppointmentPage.ResolveAlertDialog();         // accept dialog
            Assert.Equal(Pages.SchedulingAppointmentPage.URI, driver.Url);      // check if same url - page not submitted
            Assert.True(pom);
        }
        */

        [Fact]
        public void Test_succesfull_submit()
        {
            schedulingAppointmentPage.PatientSelectButtonDisplayed();
            Thread.Sleep(500);
            schedulingAppointmentPage.DateTimeFieldDisplayed(new DateTime(2022, 12, 12));
            Thread.Sleep(500);
            schedulingAppointmentPage.SubmitForm();
            Thread.Sleep(500);
        }

        [Fact]
        public void Test_selected_failed_patient()
        {
            //test pada zbog dateTime
            schedulingAppointmentPage.PatientSelectButtonDisplayed();
            Thread.Sleep(1000);
            schedulingAppointmentPage.DateTimeFieldDisplayed(new DateTime(0, 10, 2));
            Thread.Sleep(1000);
            schedulingAppointmentPage.SubmitForm();
            Thread.Sleep(500);

        }

    }
}

