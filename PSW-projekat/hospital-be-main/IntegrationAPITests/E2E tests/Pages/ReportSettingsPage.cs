using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPITests.E2E_tests.Pages
{
    public class ReportSettingsPage
    {
        private readonly IWebDriver driver;

        public const string URI = "http://localhost:4200/report-settings";

        private IWebElement OptionDeliveryDropdown => driver.FindElement(By.Id("OptionDelivery"));

        private IWebElement DeliveryDateField => driver.FindElement(By.Id("StartDeliveryDate"));

        private IWebElement DeliveryDaysField => driver.FindElement(By.Id("DeliveryDays"));

        private IWebElement DeliveryMonthsField => driver.FindElement(By.Id("DeliveryMonths"));

        private IWebElement DeliveryYearsField => driver.FindElement(By.Id("DeliveryYears"));

        private IWebElement OptionCalculationDropdown => driver.FindElement(By.Id("OptionCalculation"));

        private IWebElement CalculationDaysField => driver.FindElement(By.Id("CalculationDays"));

        private IWebElement CalculationMonthsField => driver.FindElement(By.Id("CalculationMonths"));

        private IWebElement CalculationYearsField => driver.FindElement(By.Id("CalculationYears"));

        private IWebElement SubmitButton => driver.FindElement(By.Id("Submit"));


        public ReportSettingsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool OptionDeliveryDropdownDisplayed()
        {
            return OptionDeliveryDropdown.Displayed;
        }

        public bool DeliveryDaysFieldDisplayed()
        {
            return DeliveryDaysField.Displayed;
        }

        public bool DeliveryMonthsFieldDisplayed()
        {
            return DeliveryMonthsField.Displayed;
        }

        public bool DeliveryYearsFieldDisplayed()
        {
            return DeliveryYearsField.Displayed;
        }

        public bool OptionCalculationDropdownDisplayed()
        {
            return OptionCalculationDropdown.Displayed;
        }

        public bool CalculationDaysFieldDisplayed()
        {
            return CalculationDaysField.Displayed;
        }

        public bool CalculationMonthsFieldDisplayed()
        {
            return CalculationMonthsField.Displayed;
        }

        public bool CalculationYearsFieldDisplayed()
        {
            return CalculationYearsField.Displayed;
        }

        public void Select6MonthsCalculationPeriod()
        {

            OptionCalculationDropdown.Click();
            driver.FindElement(By.Id("6monthsC")).Click();
        }

        public void SelectMonthCalculationPeriod()
        {
            OptionCalculationDropdown.Click();
            driver.FindElement(By.Id("monthC")).Click();
        }

        public void SelectYearCalculationPeriod()
        {
            OptionCalculationDropdown.Click();
            driver.FindElement(By.Id("yearC")).Click();
        }

        public void SelectCustomCalculationPeriod()
        {
            OptionCalculationDropdown.Click();
            driver.FindElement(By.Id("customC")).Click();
        }

        public void Select6MonthsDeliveryPeriod()
        {
            OptionDeliveryDropdown.Click();
            driver.FindElement(By.Id("6monthsD")).Click();
        }

        public void SelectMonthDeliveryPeriod()
        {
            OptionDeliveryDropdown.Click();
            driver.FindElement(By.Id("monthD")).Click();
        }

        public void SelectYearDeliveryPeriod()
        {
            OptionDeliveryDropdown.Click();
            driver.FindElement(By.Id("yearD")).Click();
        }

        public void SelectCustomDeliveryPeriod()
        {
            OptionDeliveryDropdown.Click();
            driver.FindElement(By.Id("customD")).Click();
        }

        public void InsertCustomDeliveryPeriod(DateTime date, string days, string months, string years)
        {
            DeliveryDaysField.Clear();
            DeliveryMonthsField.Clear();
            DeliveryYearsField.Clear();
            DeliveryDateField.SendKeys(date.ToShortDateString());
            DeliveryDaysField.SendKeys(days);
            DeliveryMonthsField.SendKeys(months);
            DeliveryYearsField.SendKeys(years);
        }

        private void SetDate(DateTime date)
        {
            DeliveryDateField.Click();
            DeliveryDateField.SendKeys(date.ToShortDateString());
            DeliveryDateField.SendKeys(Keys.Tab);
        }

        public void InsertCustomCalculationPeriod(string days, string months, string years)
        {
            CalculationDaysField.Clear();
            CalculationMonthsField.Clear();
            CalculationYearsField.Clear();
            CalculationDaysField.SendKeys(days);
            CalculationMonthsField.SendKeys(months);
            CalculationYearsField.SendKeys(years);
        }

        public void SubmitForm()
        {
            SubmitButton.Click();
        }

        public void WaitForToastDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(condition: ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(".toast-message")));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
