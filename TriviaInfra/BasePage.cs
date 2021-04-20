using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static Infrastructure.DriverManagement;

namespace Infrastructure
{
    public class BasePage
    {
        static string Environments = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


        public static IWebElement FindElement(By selector)
        {
            try
            {
                return DriverWaiter().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
            }
            catch (WebDriverTimeoutException)
            {
                return DriverWaiter().Until(drv => drv.FindElement(selector));
            }
        }

        private static WebDriverWait DriverWaiter()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(7));
        }

        public static string GetEnvironment()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            switch (Environments)
            {
                case "Ambiente de testes":
                default:
                    return "https://the-internet.herokuapp.com/";
            }
        }

    }


}

