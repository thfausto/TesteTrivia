using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Infrastructure
{
    public class DriverManagement
    {
        public static IWebDriver driver { get; private set; }

        public static void InitDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                driver.Manage().Window.Maximize();
            }
        }

        public static void KillDriver()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}
