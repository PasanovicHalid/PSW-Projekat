using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.E2E_tests
{
    public class DoctorsCouncilTest : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.LoginPage loginPage;
        private Pages.DoctorsCouncilPage reportSettingsPage;


        public DoctorsCouncilTest()
        {
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
            Thread.Sleep(3000);
            loginPage.ErrorDivDisplayed().ShouldBe(false);
            reportSettingsPage = new Pages.DoctorsCouncilPage(driver);
            reportSettingsPage.Navigate();
            Thread.Sleep(3000);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void Select_custom_period_failiure()
        {
            reportSettingsPage.ClickShowDoctorsButton();
            reportSettingsPage.InsertTopic("Tema konzilijuma");
            reportSettingsPage.ClickShowDoctorsButton();
            reportSettingsPage.InsertStartDateField(new DateTime(2022, 12, 12));
            reportSettingsPage.InsertEndDateField(new DateTime(2022, 12, 15));
            reportSettingsPage.InsertDurationFild(20);
            
            reportSettingsPage.SubmitForm();
            reportSettingsPage.WaitForToastDialog();
        }

    }
}
