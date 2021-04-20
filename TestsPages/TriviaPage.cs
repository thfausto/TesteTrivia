using OpenQA.Selenium;
using static Infrastructure.BasePage;

namespace Pages
{
    public class TriviaPage
    {

        public string url = "https://opentdb.com/";

        //Elements mapping =================================
        #region mapeamentologin
        public IWebElement ButtonBrowse()
        {
            return FindElement(By.XPath("/html/body/section/div/div/div/a[1]"));
        }

        public IWebElement InputBusca()
        {
            return FindElement(By.Name("query"));
        }

        public IWebElement ButtonSearch()
        {
            return FindElement(By.XPath("/html/body/div[1]/form/div/button"));
        }

        public IWebElement DadosID()
        {
            return FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[1]"));
        }

        public IWebElement DadosCategory()
        {
            return FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[2]"));
        }

        public IWebElement DadosType()
        {
            return FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[3]"));
        }

        public IWebElement DadosDifficulty()
        {
            return FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[4]"));
        }

        public IWebElement DadosQuestion()
        {
            return FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[5]"));
        }

        public IWebElement DadosCreatedBy()
        {
            return FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[6]"));
        }

        #endregion
        //Elements mapping =================================

        //Elements actions =================================
        #region elementosacaologin

        public void BtnBrowse()
        {
            ButtonBrowse().Click();
        }

        public void TypeCampoBusca(string busca)
        {
            InputBusca().SendKeys(busca);
        }

        public void BtnSearch()
        {
            ButtonSearch().Click();
        }


        #endregion
        //Elements actions =================================

        //Page Behaviors ===================================
        public void RealizarBusca(string busca)
        {
            BtnBrowse();
            TypeCampoBusca(busca);            
            BtnSearch();
        }
        //Page Behaviors ===================================
    }
}