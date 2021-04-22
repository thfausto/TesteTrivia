using System;
using NUnit.Framework;
using Pages;
using TechTalk.SpecFlow;
using static Infrastructure.DriverManagement;
using static Infrastructure.BasePage;
using TechTalk.SpecFlow.Assist;

namespace Trivia.Tests
{
    [Binding]
    public class BuscanoBancodeQuestoesSteps
    {

        public readonly TriviaPage triviaPage = new TriviaPage();

        int quantidadeListagem = 25;

        [BeforeScenario]
        public void TriviaPage()
        {
            InitDriver();
        }

        [Given(@"que navego para a página de busca do banco de questões")]
        public void GivenQueNavegoParaAPáginaDeBuscaDoBancoDeQuestões()
        {
            driver.Navigate().GoToUrl(triviaPage.url);
        }

        [Given(@"digito '(.*)' no campo de busca")]
        public void GivenDigitoNoCampoDeBusca(string busca)
        {
            triviaPage.BtnBrowse();
            triviaPage.RealizarBusca(busca);
        }

        [Given(@"digito no campo de busca")]
        public void GivenDigitoNoCampoDeBusca(Table table)
        {
            triviaPage.BtnBrowse();
            dynamic data = table.CreateDynamicInstance();

            triviaPage.RealizarBusca((string)data.busca);
        }

        [Given(@"digito no campo de busca e tipo de busca")]
        public void GivenDigitoNoCampoDeBuscaETipoDeBusca(Table table)
        {
            triviaPage.BtnBrowse();
            dynamic data = table.CreateDynamicInstance();

            triviaPage.RealizarTipoBusca((string)data.busca, (string)data.tipobusca);
        }

        [Given(@"digito '(.*)' no tipo de busca")]
        public void GivenDigitoNoTipoDeBusca(string tipobusca)
        {
            triviaPage.TypeBusca("tipobusca");
        }

        [Given(@"clica em browse")]
        public void GivenClicaEmBrowse()
        {
            triviaPage.BtnBrowse();
        }

        [When(@"clico no botão de buscar")]
        public void WhenClicoNoBotãoDeBuscar()
        {
            triviaPage.Buscar();
        }

        [Then(@"visualizo uma mensagem de erro com o texto '(.*)'")]
        public void ThenVisualizoUmaMensagemDeErroComOTexto(string MsgBuscaInvalidaQuestion)
        {
            Assert.IsTrue(triviaPage.MsgBuscaInvalidaQuestion().Displayed);
            Assert.IsTrue(triviaPage.MsgBuscaInvalidaQuestion().Text.Contains("No questions found."));

            KillDriver();
        }               

        [Then(@"busca exibida com sucesso")]
        public void ThenBuscaExibidaComSucesso()
        {
            Assert.IsTrue(triviaPage.DadosID().Displayed);
            Assert.IsTrue(triviaPage.DadosID().Text.Contains("9493"));

            Assert.IsTrue(triviaPage.DadosCategory().Displayed);
            Assert.IsTrue(triviaPage.DadosCategory().Text.Contains("Science: Computers"));

            Assert.IsTrue(triviaPage.DadosType().Displayed);
            Assert.IsTrue(triviaPage.DadosType().Text.Contains("Multiple Choice"));

            Assert.IsTrue(triviaPage.DadosDifficulty().Displayed);
            Assert.IsTrue(triviaPage.DadosDifficulty().Text.Contains("Easy"));

            Assert.IsTrue(triviaPage.DadosQuestion().Displayed);
            Assert.IsTrue(triviaPage.DadosQuestion().Text.Contains("What does the computer software acronym JVM stand for?"));

            Assert.IsTrue(triviaPage.DadosCreatedBy().Displayed);
            Assert.IsTrue(triviaPage.DadosCreatedBy().Text.Contains("Karen"));

            KillDriver();
        }

        [Then(@"busca completa exibida com sucesso")]
        public void ThenBuscaCompletaExibidaComSucesso()
        {
            Assert.IsTrue(triviaPage.DadosTabela().Displayed);
            Assert.IsTrue(triviaPage.DadosTabela().Text.Contains("What language does Node.js use?"));

            KillDriver();
        }

        [Then(@"contagem com sucesso")]
        public void ThenContagemComSucesso()
        {
            Assert.AreEqual(triviaPage.QuantiadeLista(), quantidadeListagem);

            Assert.IsTrue(triviaPage.Paginacao().Displayed);
            Assert.IsTrue(triviaPage.Paginacao().Text.Contains("1"));

            KillDriver();
        }        

        [Then(@"busca não exibida question")]
        public void ThenBuscaNaoExibidaQuestion()
        {
            Assert.IsTrue(triviaPage.MsgBuscaInvalidaQuestion().Displayed);
            Assert.IsTrue(triviaPage.MsgBuscaInvalidaQuestion().Text.Contains("No questions found."));

            KillDriver();
        }

        [Then(@"busca não exibida user")]
        public void ThenBuscaNaoExibidaUser()
        {
            Assert.IsTrue(triviaPage.MsgBuscaInvalidaUser().Displayed);
            Assert.IsTrue(triviaPage.MsgBuscaInvalidaUser().Text.Contains("No User Found!"));

            KillDriver();
        }

        [Then(@"busca não exibida category")]
        public void ThenBuscaNaoExibidaCategory()
        {
            Assert.IsTrue(triviaPage.MsgBuscaInvalidaCategory().Displayed);
            Assert.IsTrue(triviaPage.MsgBuscaInvalidaCategory().Text.Contains("No questions found."));

            KillDriver();
        }
               

        [TearDown]
        public void TearDown()
        {
            KillDriver();
        }
    }
}
