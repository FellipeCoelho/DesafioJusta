using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEccomerce.Pages
{
    class Authentication
    {
        private IWebDriver driver;

        //campo email para realizar o login
        private  IWebElement emailLogin()
        {
            return driver.FindElement(By.Id("email"));
        }

        private IWebElement passwordLogin()
        {
            return driver.FindElement(By.Id("passwd"));
        }

        //botao verde do sing in, somente para essa classe
        private IWebElement botaoSignIn2()
        {
            return driver.FindElement(By.Id("SubmitLogin"));
        }
            
        public Authentication(IWebDriver driver)
        {
            this.driver = driver;
        }

        //para esse exemplo, os parametros podem ser passados nessa mesma clase, nao estamos testando o login de qualquer forma
        public void RealizarSingIn()
        {
            emailLogin().SendKeys("candidato@justa.com.vc");
            passwordLogin().SendKeys("tamojusto");
            botaoSignIn2().Click();
        }
        
    }
}
