using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEccomerce.Pages
{
    class Address
    {
        private IWebDriver driver;

        //localizando checkbox endereços iguals de cobrança e entrega
        private IWebElement checkboxEndereco()
        {
            return driver.FindElement(By.Id("addressesAreEquals"));
        }
        //localizando o texto do endereco na page
        private IWebElement enderecoEntrega()
        {
            return driver.FindElement(By.XPath("(//li[@class='address_address1 address_address2'])"));
        }

        //localizando o texto do cidade, estado e cep (a aplicação deixa em uma unica string)
        private IWebElement endereco2Entrega() 
        {
            return driver.FindElement(By.XPath("(//li[@class='address_city address_state_name address_postcode'])"));
        }

        //os mesmos atributos do endereco de entrega, foi adicionado um indice no xpath
        private IWebElement enderecoCobranca()
        {
            return driver.FindElement(By.XPath("(//li[@class='address_address1 address_address2'])[2]"));
        }

        private IWebElement endereco2Cobranca()
        {
            return driver.FindElement(By.XPath("(//li[@class='address_city address_state_name address_postcode'])[2]"));
        }

        //localizando o botao para alterar dados de entrega
        private IWebElement botaoUpdateDelivery()
        {
            return driver.FindElement(By.XPath("(//a[@class='button button-small btn btn-default'])"));
        }

        //localizando o botão para alterar dados de cobrança
        private IWebElement botaoUpdateBilling()
        {
            return driver.FindElement(By.XPath("(//a[@class='button button-small btn btn-default'])[2]"));
        }

        //botao prosseguir da pagina address (tem o xpath diferente do botao de sumary)
        private IWebElement BotaoProsseguir()
        {
            return driver.FindElement(By.CssSelector("button[class='button btn btn-default button-medium']"));
        }

        public Address(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void ScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public void ClicarCheckBox()
        {
            checkboxEndereco().Click();
        }

        //verificando se o endereço que está escrito na tela foi realmente alterado
        public void verificaDadosEntrega(String endereco, String cidade, String estado, String cep)
        {
            Assert.AreEqual(endereco, enderecoEntrega().Text);
            Assert.AreEqual(cidade.Trim()+", "+estado.Trim()+" "+cep, endereco2Entrega().Text);//ajustando a estrutura do texto exatamente com está no site (as string do código estavam iniciando com espaco em branco por isso o metrodo Trim())
        }

        public void verificaDadosCobranca(String endereco, String cidade, String estado, String cep)
        {
            Assert.AreEqual(endereco, enderecoCobranca().Text);
            Assert.AreEqual(cidade.Trim() + ", " + estado.Trim() + " " + cep, endereco2Cobranca().Text);//mesma coisa do metodo anterior
        }

        //clicando no botao para editar endereco de entrega
        public void EditarEnderecoEntrega()
        {
            ClicarCheckBox();
            ScrollDown();
            botaoUpdateDelivery().Click();
        }

        //clicando no botao para editar endero de cobranca
        public void EditarEnderecoCobranca()
        {
            ClicarCheckBox();
            ScrollDown();
            botaoUpdateBilling().Click();
        }

        //prosseguindo para o checkout
        public void Prosseguir()
        {
            ScrollDown();
            BotaoProsseguir().Click();
        }
        
    }
}
