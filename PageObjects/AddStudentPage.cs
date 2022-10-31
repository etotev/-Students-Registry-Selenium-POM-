using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.PageObjects
{
    internal class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }
        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement FieldName => driver.FindElement(By.Id("name"));
        public IWebElement FieldEmail => driver.FindElement(By.Id("email"));
        public IWebElement SubmitButton => driver.FindElement(By.CssSelector("body > form > button"));
        public IWebElement ErrorMessage => driver.FindElement(By.CssSelector("body > div"));

        public string GetErrorMsg()
        {
            this.SubmitButton.Click();
            return ErrorMessage.Text;
        }

        public void AddStudent(string name, string email) 
        {
            this.FieldName.SendKeys(name);
            this.FieldEmail.SendKeys(email);
            this.SubmitButton.Click();
        }

        public string GetErrorMsg(string name, string email)
        {
            this.FieldName.SendKeys(name);
            this.FieldEmail.SendKeys(email);
            this.SubmitButton.Click();

            return ErrorMessage.Text;
        }

    }
}
