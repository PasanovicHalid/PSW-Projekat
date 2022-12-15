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
            loginPage.InsertUsername("marko");
            loginPage.InsertPassword("123");
            loginPage.SubmitForm();
            loginPage.ErrorDivDisplayed().ShouldBe(false);

            schedulingAppointmentPage = new Pages.SchedulingAppointmentPage(driver);
            schedulingAppointmentPage.Navigate();

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
            schedulingAppointmentPage.DateTimeFieldDisplayed(new DateTime(2022, 12, 12));
            schedulingAppointmentPage.SubmitForm();
        }

        [Fact]
        public void Test_selected_failed_patient()
        {
            //test pada zbog dateTime
            schedulingAppointmentPage.PatientSelectButtonDisplayed();
            schedulingAppointmentPage.DateTimeFieldDisplayed(new DateTime(0, 10, 2));
            schedulingAppointmentPage.SubmitForm();

        }

    }
}

