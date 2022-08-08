using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEccomerce.Pages
{
    class Home
    {
        private IWebDriver driver;

        private IWebElement BotaoSingIn()
        {
            return driver.FindElement(By.ClassName("login"));
        }
        
        private IWebElement BarraDePesquisa()
        {
            return driver.FindElement(By.Id("search_query_top"));
        }

        private IWebElement BotaoPesquisa()
        {
            return driver.FindElement(By.CssSelector("button[name=submit_search"));
        }

        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AbrirSite(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }


        public void ClicarEmSingIn()
        {
            BotaoSingIn().Click();
        }

        //para esse exemplo nao precisamos parametrizar qual produto estamos buscando
        public void PesquisarProduto()
        {
            BarraDePesquisa().SendKeys("Dress");
            BotaoPesquisa().Click();
        }

    }
}
