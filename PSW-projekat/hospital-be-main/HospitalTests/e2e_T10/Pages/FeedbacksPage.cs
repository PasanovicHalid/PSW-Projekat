using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.e2e_T10.Pages
{
    public class FeedbacksPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/feedbacks";

        private IWebElement ApproveButton => driver.FindElement(By.Id("approveButton"));
        private IWebElement RejectButton => driver.FindElement(By.Id("rejectButton"));

        public FeedbacksPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

        public bool ApproveButtonElementDisplayed()
        {
            return ApproveButton.Displayed;
        }

        public bool RejectButtonElementDisplayed()
        {
            return RejectButton.Displayed;
        }

        public void ApproveFeedback()
        {
            ApproveButton.Click();
        }

        public void RejectFeedback()
        {
            RejectButton.Click();
        }

        public void WaitForApproveButtonToDisapear()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("approveButton")));
        }
    }
}
