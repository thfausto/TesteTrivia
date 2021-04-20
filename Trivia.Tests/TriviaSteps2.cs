using System;
using NUnit.Framework;
using Pages;
using TechTalk.SpecFlow;
using static Infrastructure.DriverManagement;

namespace Trivia.Tests
{
    [Binding]
    public class TriviaSteps2
    {
        public TriviaPage triviaPage;

        [BeforeScenario]
        public void TriviaPage()
        {
            InitDriver();
        }

        [Given(@"acesso o site da Trivia Teste")]
        public void GivenAcessoOSiteDaTriviaTeste()
        {
            driver.Navigate().GoToUrl("https://opentdb.com/");
        }
        
        [Given(@"clica em browse de busca")]
        public void GivenClicaEmBrowseDeBusca()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"realiza busca valida")]
        public void WhenRealizaBuscaValida()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"busca exibida realizada")]
        public void ThenBuscaExibidaRealizada()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
