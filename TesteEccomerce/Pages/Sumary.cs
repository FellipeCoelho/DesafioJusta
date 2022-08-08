using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEccomerce.Pages
{
    class Sumary
    {
        private IWebDriver driver;

        //botao prosseguir da page do sumário
        private IWebElement BotaoProsseguir()
        {
            return driver.FindElement(By.CssSelector("a[class='button btn btn-default standard-checkout button-medium']"));
        }

        public Sumary(IWebDriver driver)
        {
            this.driver = driver;

        }
        public void ScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        //seguindo para a área de endereço (que é nosso foco principal)
        public void Prosseguir()
        {
            ScrollDown();
            BotaoProsseguir().Click();
        }
    }
}
