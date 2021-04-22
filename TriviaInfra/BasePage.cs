using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<IWebElement> FindElements(By selector)
        {
            try
            {
                return DriverWaiter().Until(drv => drv.FindElements(selector)).ToList();
            }
            catch (WebDriverTimeoutException)
            {
                return DriverWaiter().Until(drv => drv.FindElements(selector)).ToList();
            }
        }

        private static WebDriverWait DriverWaiter()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(7));
        }            

    }


}

