using NUnit.Framework;
using Students_Registry_Selenium_POM_Tests.PageObjects;

namespace Students_Registry_Selenium_POM_Tests.Tests
{
    internal class HomePageTests : BaseTest
    {
        [Test]
        public void Test_HomePage_Title_And_Header()
        {
            var page = new HomePage(driver);
            page.Open();

            Assert.That("MVC Example", Is.EqualTo(page.GetPageTitle()));
            Assert.That("Students Registry", Is.EqualTo(page.GetPageHeadingText()));
        }

        [Test]
        public void Test_HomePage_Url()
        {
            var page = new HomePage(driver);
            page.Open();

            Assert.That(page.IsOpen());
        }

        [Test]
        public void Test_HomePage_Links()
        {
            var page = new HomePage(driver);
            page.Open();

            page.GoToHomePage();

            Assert.That(page.IsOpen());

            page.GoToViewStudentsPage();

            var viewStudentsPage = new ViewStudentsPage(driver);

            Assert.That(viewStudentsPage.IsOpen());

            driver.Navigate().Back();

            page.GoToAddStudentPage();

            var addStudentPage = new AddStudentPage(driver);

            Assert.That(addStudentPage.IsOpen());
        }
        

        [Test]
        public void Test_HomePage_CountOfStudents()
        {
            var page = new HomePage(driver);
            page.Open();

            Assert.IsTrue(page.GetStudentsCount() > 0);
        }

    }
}
