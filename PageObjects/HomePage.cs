using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.PageObjects
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/";

        public IWebElement ElementStudentsCount => driver.FindElement(By.CssSelector("b"));

        public int GetStudentsCount()
        {
            int count = int.Parse(ElementStudentsCount.Text);
            return count;
        }


    }
}
