using NUnit.Framework;
using Students_Registry_Selenium_POM_Tests.PageObjects;
using System;

namespace Students_Registry_Selenium_POM_Tests.Tests
{
    internal class ViewStudentsPageTests : BaseTest
    {
        [Test]
        public void Test_ViewStudentsPage_Title_And_Header()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();

            Assert.That("Students", Is.EqualTo(page.GetPageTitle()));
            Assert.That("Registered Students", Is.EqualTo(page.GetPageHeadingText()));
        }

        [Test]
        public void Test_ViewStudentsPage_Url()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();

            Assert.That(page.IsOpen());
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();

            Assert.That(page.IsOpen());

            page.GoToAddStudentPage();

            var addStudentPage = new AddStudentPage(driver);

            Assert.That(addStudentPage.IsOpen());

            page.GoToHomePage();

            var homePage = new HomePage(driver);

            Assert.That(homePage.IsOpen());
        }

        [Test]

        public void Test_ViewStudentsPage_ListOfStudentsNotEmpty()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();

            Assert.IsTrue(page.ListItemsStudents.Count > 0);
        }

    }
}
