using System;
using NUnit.Framework;
using Pages;
using TechTalk.SpecFlow;
using static Infrastructure.DriverManagement;

namespace Trivia.Tests
{
    [Binding]
    public class TriviaSteps
    {

        public TriviaPage triviaPage;

        [BeforeScenario]
        public void TriviaPage()
        {
            InitDriver();
        }

        [Given(@"acesso o site da Trivia")]
        public void GivenAcessoOSiteDaTrivia()
        {
            driver.Navigate().GoToUrl(triviaPage.url);
        }

        [Given(@"clica em browse")]
        public void GivenClicaEmBrowse()
        {
            triviaPage.BtnBrowse();
        }

        [When(@"realiza busca")]
        public void WhenRealizaBusca(string busca)
        {
            triviaPage.TypeCampoBusca(busca);
        }

        [Then(@"busca exibida com sucesso")]
        public void ThenBuscaExibidaComSucesso()
        {
            triviaPage.RealizarBusca("What is Hellboy's true name?");

            Assert.IsTrue(triviaPage.DadosID().Displayed);
            Assert.IsTrue(triviaPage.DadosID().Text.Contains("6585"));

            Assert.IsTrue(triviaPage.DadosCategory().Displayed);
            Assert.IsTrue(triviaPage.DadosCategory().Text.Contains("Entertainment: Comics"));

            Assert.IsTrue(triviaPage.DadosType().Displayed);
            Assert.IsTrue(triviaPage.DadosType().Text.Contains("Multiple Choice"));

            Assert.IsTrue(triviaPage.DadosDifficulty().Displayed);
            Assert.IsTrue(triviaPage.DadosDifficulty().Text.Contains("Medium"));

            Assert.IsTrue(triviaPage.DadosQuestion().Displayed);
            Assert.IsTrue(triviaPage.DadosQuestion().Text.Contains("What is Hellboy's true name?"));

            Assert.IsTrue(triviaPage.DadosCreatedBy().Displayed);
            Assert.IsTrue(triviaPage.DadosCreatedBy().Text.Contains("Athaswind"));
        }
    }
}
