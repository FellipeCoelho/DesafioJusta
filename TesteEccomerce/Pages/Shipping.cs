using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEccomerce.Pages
{
    class Shipping
    {
        private IWebDriver driver;

        //checkbox dos termos de serviços
        private IWebElement termosDeServico()
        {
            return driver.FindElement(By.Id("cgv"));
        }

        private IWebElement botaoProsseguir()
        {
           return driver.FindElement(By.CssSelector("button[class='button btn btn-default standard-checkout button-medium']"));          
        }

        public Shipping(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ConcordarTermosServicos()
        {
            termosDeServico().Click();
        }

        public void ProsseguirCheckout()
        {
            botaoProsseguir().Click();
        }
    }
}
