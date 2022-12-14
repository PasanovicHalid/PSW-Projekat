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

namespace IntegrationAPITests.E2E_tests
{
    public class ReportSettingsTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.LoginPage loginPage;
        private Pages.ReportSettingsPage reportSettingsPage;
        //private Pages.CreateProductPage createProductPage;
        //private int productsCount = 0;

        public ReportSettingsTests()
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
            loginPage.InsertUsername("pera");
            loginPage.InsertPassword("123");
            loginPage.SubmitForm();
            Thread.Sleep(3000);
            loginPage.ErrorDivDisplayed().ShouldBe(false);
            reportSettingsPage = new Pages.ReportSettingsPage(driver);
            reportSettingsPage.Navigate();
            Thread.Sleep(3000);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void Select_6_months_period_successfully()
        {
            reportSettingsPage.Select6MonthsDeliveryPeriod();
            reportSettingsPage.Select6MonthsCalculationPeriod();
            reportSettingsPage.SubmitForm();
            try
            {
                 reportSettingsPage.WaitForToastDialog();
            } catch (WebDriverTimeoutException) { }
        }

        [Fact]
        public void Select_custom_period_successfully()
        {
            reportSettingsPage.SelectCustomCalculationPeriod();
            reportSettingsPage.SelectCustomDeliveryPeriod();
            reportSettingsPage.InsertCustomDeliveryPeriod(DateTime.Today, "5", "3", "1");
            reportSettingsPage.InsertCustomCalculationPeriod("2", "3", "1");
            reportSettingsPage.SubmitForm();
            try
            {
                reportSettingsPage.WaitForToastDialog();
                Assert.False(true);
            }
            catch (WebDriverTimeoutException) { }
        }

        [Fact]
        public void Select_custom_period_failiure()
        {
            reportSettingsPage.SelectCustomCalculationPeriod();
            reportSettingsPage.SelectCustomDeliveryPeriod();
            reportSettingsPage.InsertCustomDeliveryPeriod(DateTime.Today, "40", "3", "1");
            reportSettingsPage.InsertCustomCalculationPeriod("39", "3", "1");
            reportSettingsPage.SubmitForm();
            reportSettingsPage.WaitForToastDialog();
        }
    }
}
