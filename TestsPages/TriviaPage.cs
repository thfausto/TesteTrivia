using OpenQA.Selenium;
using static Infrastructure.BasePage;

namespace Pages
{
    public class TriviaPage
    {

        public string url = "https://opentdb.com/";

        //Elements mapping =================================
        #region mapeamento
        public IWebElement ButtonBrowse()
        {
            return FindElement(By.XPath("/html/body/section/div/div/div/a[1]"));
        }

        public IWebElement InputBusca()
        {
            return FindElement(By.Id("query"));
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

        public IWebElement DadosTabela()
        {
            return FindElement(By.XPath("/html/body/div[2]/table/tbody"));
        }
                

        public int QuantiadeLista()
        {
            return FindElements(By.XPath("/html/body/div[2]/table/tbody/tr")).Count;
        }

        public IWebElement Paginacao()
        {
            return FindElement(By.XPath("/html/body/div[2]/center/ul/li[1]/a"));
        }

        public IWebElement InputTipoBusca() => FindElement(By.Id("type"));            


        public IWebElement MsgBuscaInvalidaQuestion()
        {
            return FindElement(By.XPath("/html/body/div[2]/div"));
        }

        public IWebElement MsgBuscaInvalidaUser()
        {
            return FindElement(By.XPath("/html/body/div[2]/div"));
        }

        public IWebElement MsgBuscaInvalidaCategory()
        {
            return FindElement(By.XPath("/html/body/div[2]/div"));
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

        public void TypeBusca(string tipobusca)
        {
            InputTipoBusca().SendKeys(tipobusca);
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
            TypeCampoBusca(busca);            
            BtnSearch();
        }

        public void Buscar()
        {
            BtnSearch();
        }

        public void RealizarTipoBusca(string busca, string tipobusca)
        {
            TypeCampoBusca(busca);
            TypeBusca(tipobusca);
            BtnSearch();
        }
        //Page Behaviors ===================================
    }
}