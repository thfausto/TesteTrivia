using OpenQA.Selenium;
using static Infrastructure.BasePage;

namespace Pages
{
    public class LoginPage
    {

        public string url = GetEnvironment() + "login";

        //Elements mapping =================================
        #region mapeamentologin
        public IWebElement InputCampoUsername()
        {
            return FindElement(By.Id("username"));
        }

        public IWebElement InputCampoPassword()
        {
            return FindElement(By.Id("password"));
        }

        public IWebElement ButtonLogin()
        {
            return FindElement(By.ClassName("radius"));
        }

        public IWebElement MsgLogin()
        {
            return FindElement(By.Id("flash"));
        }

        #endregion        
        //Elements mapping =================================

        //Elements actions =================================
        #region elementosacaologin
        public void TypeCampoUsername(string username)
        {
            InputCampoUsername().SendKeys(username);
        }

        public void TypeCampoPassword(string password)
        {
            InputCampoPassword().SendKeys(password);
        }

        public void BtnLogin()
        {
            ButtonLogin().Click();
        }
        #endregion
        //Elements actions =================================

        //Page Behaviors ===================================
        public void RealizarLogin(string username, string password)
        {
            TypeCampoUsername(username);
            TypeCampoPassword(password);
            BtnLogin();
        }
        //Page Behaviors ===================================
    }
}