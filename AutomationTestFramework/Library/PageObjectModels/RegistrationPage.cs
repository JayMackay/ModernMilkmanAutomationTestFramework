﻿using OpenQA.Selenium;
using AutomationTestFramework.ConfigurationFiles;
using OpenQA.Selenium.Interactions;

namespace AutomationTestFramework.Library.PageObjectModels
{
    public class RegistrationPage
    {
        private IWebDriver _driver;
        private string registrationPageUrl = AppConfigReader.RegistrationPageUrl;

        //Page Elements
        private IWebElement WelcomeMessage => this._driver.FindElement(By.XPath("/html/body/section[@class='signup-page']/h1"));
        private IWebElement FirstNameInput => this._driver.FindElement(By.Id("forename"));
        private IWebElement SurnameInput => this._driver.FindElement(By.Id("surname"));
        private IWebElement EmailInput => this._driver.FindElement(By.Id("email"));
        private IWebElement ConfirmEmailInput => this._driver.FindElement(By.Id("email1"));
        private IWebElement PhoneNumberInput => this._driver.FindElement(By.Id("phoneNo"));
        private IWebElement PasswordInput => this._driver.FindElement(By.Id("password"));
        private IWebElement TermsCheck => this._driver.FindElement(By.XPath("//*[@id='signup']/div[4]/div[2]/div/label"));
        private IWebElement CreateAccountButton => this._driver.FindElement(By.XPath("//*[@id='addCustomer']/img"));
        private IWebElement InvalidFormCheck => this._driver.FindElement(By.Id("swal2-content"));

        //Page Object Model Constructor
        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //Methods
        public void VisitRegistrationPage()
        {
            _driver.Navigate().GoToUrl(registrationPageUrl);
        }

        public string RegistrationPageWelcomeMessage()
        {
            return WelcomeMessage.Text;
        }

        public void RegisterNewUser(string firstName, string surname, string email, string confirmEmail, string phoneNumber, string password)
        {
            Actions action = new Actions(_driver); //Initializes Selenium interactions

            //User Form Input
            FirstNameInput.SendKeys(firstName);
            SurnameInput.SendKeys(surname);
            EmailInput.SendKeys(email);
            ConfirmEmailInput.SendKeys(confirmEmail);
            PhoneNumberInput.SendKeys(phoneNumber);
            PasswordInput.SendKeys(password);
            TermsCheck.Click();
            //action.MoveToElement(TermsCheck).MoveByOffset(5, 0).Click();
            CreateAccountButton.Click();
        }

        public bool BadEmailInput()
        {
            if (InvalidFormCheck.Enabled)
            {
                return true;
            }
            return false;
        }
    }
}
