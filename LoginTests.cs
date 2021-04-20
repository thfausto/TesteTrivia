using Pages;
using NUnit.Framework;
using static Infrastructure.DriverManagement;

namespace Tests
{
    public class LoginTests
    {
        public LoginPage loginPage;

        [SetUp]
        public void SetUp()
        {
            InitDriver();
            loginPage = new LoginPage();

            driver.Navigate().GoToUrl(loginPage.url);
        }

        [Test, Order(1)]
        public void LogincomSucesso()
        {
            loginPage.RealizarLogin("tomsmith", "SuperSecretPassword!");

            Assert.IsTrue(loginPage.MsgLogin().Displayed);
            Assert.IsTrue(loginPage.MsgLogin().Text.Contains("You logged into a secure area!"));
        }

        [Test, Order(2)]
        public void LogincomUsernameInvalido()
        {
            loginPage.RealizarLogin("tomsmit", "SuperSecretPassword!");

            Assert.IsTrue(loginPage.MsgLogin().Displayed);
            Assert.IsTrue(loginPage.MsgLogin().Text.Contains("Your username is invalid!"));
        }

        [Test, Order(3)]
        public void LogincomPasswordInvalido()
        {
            loginPage.RealizarLogin("tomsmith", "SuperSecretPassword");

            Assert.IsTrue(loginPage.MsgLogin().Displayed);
            Assert.IsTrue(loginPage.MsgLogin().Text.Contains("Your password is invalid!"));
        }

        [Test, Order(4)]
        public void LogincomUsernameePasswordInvalidos()
        {
            loginPage.RealizarLogin("tomsmith123", "SuperSecretPassword!123");

            Assert.IsTrue(loginPage.MsgLogin().Displayed);
            Assert.IsTrue(loginPage.MsgLogin().Text.Contains("Your username is invalid!"));
        }

        [TearDown]
        public void TearDown()
        {
            KillDriver();
        }
    }
}