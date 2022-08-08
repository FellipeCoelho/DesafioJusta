using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEccomerce.Pages
{
    class AddressUpdate
    {
        private IWebDriver driver;
        private SelectElement selectElement;

        private IWebElement CampoEndereco()
        {
            return driver.FindElement(By.Id("address1"));
        }

        private IWebElement CampoEndereco2()
        {
            return driver.FindElement(By.Id("address2"));
        }

        private IWebElement CampoCidade()
        {
            return driver.FindElement(By.Id("city"));
        }
        private IWebElement ComboBoxEstado()
        {
            return driver.FindElement(By.Id("id_state"));
        }

        private IWebElement CampoCEP()
        {
            return driver.FindElement(By.Id("postcode"));
        }

        private IWebElement BotaoSalvar()
        {
            return driver.FindElement(By.Id("submitAddress"));
        }

        public AddressUpdate(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        //descendo a page para visualizar os outros elementos
         public void ScrollMiddle()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(500,500)");
        }
        //

        public void AlterarEndereco(String endereco)
        {
            CampoEndereco().Clear();
            CampoEndereco().SendKeys(endereco);
            CampoEndereco2().Clear();//so para este teste vamos desconsiderar o campo endereço2 para facilitar a validação dos dados
        }

        public void AlterarCidade(String cidade)
        {
            ScrollMiddle();
            CampoCidade().Clear();
            CampoCidade().SendKeys(cidade);
        }

        public void AlterarEstado(String estado)
        {
            selectElement = new SelectElement(ComboBoxEstado());
            selectElement.SelectByText(estado);
        }
            
        public void AlterarCep(String cep)
        {
            CampoCEP().Clear();
            CampoCEP().SendKeys(cep);
        }

        public void ClicarEmSalvar()
        {
            BotaoSalvar().Click();
        }

    }
}
