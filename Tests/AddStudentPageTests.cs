using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Students_Registry_Selenium_POM_Tests.PageObjects;
using System;

namespace Students_Registry_Selenium_POM_Tests.Tests
{
    internal class AddStudentPageTests : BaseTest

    {

        public IWebElement NewLastStudent => driver.FindElement(By.CssSelector("body > ul > li:last-child"));

        [Test]
        public void Test_AddStudentPage_Title_And_Header()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            Assert.That("Add Student", Is.EqualTo(page.GetPageTitle()));
            Assert.That("Register New Student", Is.EqualTo(page.GetPageHeadingText()));
        }

        [Test]
        public void Test_AddStudentPage_Url()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            Assert.That(page.IsOpen());
        }


        [Test]
        public void Test_AddStudentPage_Links()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            Assert.That(page.IsOpen());

            page.GoToViewStudentsPage();

            var viewStudentsPage = new ViewStudentsPage(driver);

            Assert.That(viewStudentsPage.IsOpen());

            page.GoToHomePage();

            var homePage = new HomePage(driver);

            Assert.That(homePage.IsOpen());
        }

        [Test]
        public void Test_AddStudentPage_AddingNewStudent()
        {
            var page = new HomePage(driver);
            page.Open();

            int oldCount = page.GetStudentsCount();

            page.GoToAddStudentPage();

            var addStudentPage = new AddStudentPage(driver);

            string NameToAdd = "Gosho" + DateTime.Now.Ticks;
            string emailToAdd = $"{NameToAdd}@abv.bg";


            addStudentPage.AddStudent(NameToAdd, emailToAdd);
            string nameToCompare = $"{NameToAdd} ({emailToAdd})";

            Assert.That("Registered Students", Is.EqualTo(page.GetPageHeadingText()));
            page.GoToViewStudentsPage();
            var viewStudentsPage = new ViewStudentsPage(driver);
            var allStudents = viewStudentsPage.GetStudentsArray();

            Assert.Contains(nameToCompare, allStudents);

            page.GoToHomePage();
            int newCount = page.GetStudentsCount();

            Assert.IsTrue(oldCount < newCount);
        }

        [Test]
        public void Test_AddStudentPage_InvalidEmail()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            var message = page.GetErrorMsg("Name", "");

            Assert.AreEqual("Cannot add student. Name and email fields are required!", message);
        }

        [Test]
        public void Test_AddStudentPage_InvalidName()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            var message = page.GetErrorMsg("", "email@gmail.com");

            Assert.AreEqual("Cannot add student. Name and email fields are required!", message);
        }
    }
}
