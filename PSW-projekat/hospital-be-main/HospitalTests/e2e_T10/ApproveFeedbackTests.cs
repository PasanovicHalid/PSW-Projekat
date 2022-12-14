using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace HospitalTests.e2e_T10
{
    public class ApproveFeedbackTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.FeedbacksPage feedbacksPage;

        public ApproveFeedbackTests()
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

            feedbacksPage = new Pages.FeedbacksPage(driver);
            feedbacksPage.Navigate();

            Assert.True(feedbacksPage.ApproveButtonElementDisplayed());
            Assert.True(feedbacksPage.RejectButtonElementDisplayed());

        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void Test_approve_feedback()
        {
            feedbacksPage.ApproveFeedback();          // insert all values except name

            feedbacksPage.WaitForApproveButtonToDisapear();         // wait for alert dialog
            Assert.Equal(feedbacksPage.GetDialogMessage(), Pages.CreateFeedbackPage.FeedBackCreatedMessage);
            feedbackPage.ResolveAlertDialog();         // accept dialog
            Assert.Equal(driver.Url, Pages.CreateFeedbackPage.URI);      // check if same url - page not submitted
        }
    }
}
