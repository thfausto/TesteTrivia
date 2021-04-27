using NUnit.Framework;
using Pages;
using TechTalk.SpecFlow;
using static Infrastructure.DriverManagement;
using TechTalk.SpecFlow.Assist;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;

namespace Trivia.Tests
{
    [Binding]
    public class BuscanoBancodeQuestoesSteps
    {
        public readonly TriviaPage triviaPage = new TriviaPage();

        private ScenarioContext _scenarioContext;        

        int quantidadeListagem = 25;

        public static ExtentReports extent = null;

        ExtentTest test = null;

        public BuscanoBancodeQuestoesSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [OneTimeSetUp]
        public static void ExtentStart()
        {
            extent = new ExtentReports();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\DEV\TesteTrivia\Trivia.Tests\ExtentReports\BuscanoBancodeQuestoes.html");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public static void ExtentClose()
        {
            extent.Flush();
        }           

        [BeforeScenario]
        public static void BeforeScenario()
        {
            InitDriver();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {            
            ExtentStart();
        }

        [Given(@"que navego para a página de busca do banco de questões")]
        public void GivenQueNavegoParaAPáginaDeBuscaDoBancoDeQuestões()
        {
            try
            {
                test = extent.CreateTest(_scenarioContext.ScenarioInfo.Title).Info("Teste Iniciado");
                driver.Navigate().GoToUrl(triviaPage.url);
                test.Log(Status.Pass, "Browser Chrome Aberto");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }            
        }

        [Given(@"digito '(.*)' no campo de busca")]
        public void GivenDigitoNoCampoDeBusca(string busca)
        {
            try
            {
                triviaPage.BtnBrowse();
                triviaPage.RealizarBusca(busca);

                test.Log(Status.Pass, "Busca Realizada");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }            
        }

        [Given(@"digito no campo de busca")]
        public void GivenDigitoNoCampoDeBusca(Table table)
        {
            try
            {
                triviaPage.BtnBrowse();
                dynamic data = table.CreateDynamicInstance();

                triviaPage.RealizarBusca((string)data.busca);

                test.Log(Status.Pass, "Campo de Busca Preenchido");
                test.Log(Status.Pass, "Busca Realizada");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }            
        }

        [Given(@"digito no campo de busca e tipo de busca")]
        public void GivenDigitoNoCampoDeBuscaETipoDeBusca(Table table)
        {
            try
            {
                triviaPage.BtnBrowse();
                dynamic data = table.CreateDynamicInstance();

                triviaPage.RealizarTipoBusca((string)data.busca, (string)data.tipobusca);

                test.Log(Status.Pass, "Campo de Busca Preenchido");
                test.Log(Status.Pass, "Busca Realizada");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }            
        }

        [Given(@"digito '(.*)' no tipo de busca")]
        public void GivenDigitoNoTipoDeBusca(string tipobusca)
        {
            try
            {
                triviaPage.TypeBusca("tipobusca");

                test.Log(Status.Pass, "Campo Tipo de Busca Preenchido");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }            
        }

        [Given(@"clica em browse")]
        public void GivenClicaEmBrowse()
        {
            try
            {
                triviaPage.BtnBrowse();
                test.Log(Status.Pass, "Clica no Botão Browse");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }            
        }

        [When(@"clico no botão de buscar")]
        public void WhenClicoNoBotãoDeBuscar()
        {
            try
            {
                triviaPage.Buscar();
                test.Log(Status.Pass, "Clica no Botão Buscar");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
        }

        [Then(@"visualizo uma mensagem de erro com o texto '(.*)'")]
        public void ThenVisualizoUmaMensagemDeErroComOTexto(string MsgBuscaInvalidaQuestion)
        {
            try
            {
                Assert.IsTrue(triviaPage.MsgBuscaInvalidaQuestion().Displayed);
                Assert.IsTrue(triviaPage.MsgBuscaInvalidaQuestion().Text.Contains("No questions found."));

                test.Log(Status.Pass, "Comparando Mensagem");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }

            TearDown();
        }               

        [Then(@"busca exibida com sucesso")]
        public void ThenBuscaExibidaComSucesso()
        {
            try
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

                test.Log(Status.Pass, "Comparando os Dados da Busca");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }

            TearDown();
        }

        [Then(@"busca completa exibida com sucesso")]
        public void ThenBuscaCompletaExibidaComSucesso()
        {
            try
            {
                Assert.IsTrue(triviaPage.DadosTabela().Displayed);
                Assert.IsTrue(triviaPage.DadosTabela().Text.Contains("What language does Node.js use?"));

                test.Log(Status.Pass, "Comparando os Dados da Busca");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }

            TearDown();
        }

        [Then(@"contagem com sucesso")]
        public void ThenContagemComSucesso()
        {
            try
            {
                Assert.AreEqual(triviaPage.QuantiadeLista(), quantidadeListagem);

                Assert.IsTrue(triviaPage.Paginacao().Displayed);
                Assert.IsTrue(triviaPage.Paginacao().Text.Contains("1"));

                test.Log(Status.Pass, "Realizando a Contagem de Paginação");                
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);               
            }

            TearDown();

        }        

        [Then(@"busca não exibida question")]
        public void ThenBuscaNaoExibidaQuestion()
        {
            try
            {
                Assert.IsTrue(triviaPage.MsgBuscaInvalidaQuestion().Displayed);
                Assert.IsTrue(triviaPage.MsgBuscaInvalidaQuestion().Text.Contains("No questions found."));

                test.Log(Status.Pass, "Comparando Mensagem");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }

            TearDown();
        }

        [Then(@"busca não exibida user")]
        public void ThenBuscaNaoExibidaUser()
        {
            try
            {
                Assert.IsTrue(triviaPage.MsgBuscaInvalidaUser().Displayed);
                Assert.IsTrue(triviaPage.MsgBuscaInvalidaUser().Text.Contains("No User Found!"));

                test.Log(Status.Pass, "Comparando Mensagem");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }

            TearDown();
        }

        [Then(@"busca não exibida category")]
        public void ThenBuscaNaoExibidaCategory()
        {
            try
            {
                Assert.IsTrue(triviaPage.MsgBuscaInvalidaCategory().Displayed);
                Assert.IsTrue(triviaPage.MsgBuscaInvalidaCategory().Text.Contains("No questions found."));

                test.Log(Status.Pass, "Comparando Mensagem");
            }
            catch (System.Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }          
            
            TearDown();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            ExtentClose();
        }

        [TearDown]
        public void TearDown()
        {
            KillDriver();
        }
    }
}
