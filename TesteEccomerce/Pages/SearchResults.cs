using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEccomerce.Pages
{
    class SearchResults
    {
        private IWebDriver driver;

        //container do produto(para as opções que estao escondidas)
        private IWebElement ContainerProduto()
        {
            return driver.FindElement(By.ClassName("product-container")); 
        }     
        
        //boto para adicionar ao carrinho de compras
        private IWebElement BotaoAddCart()
        {
            return driver.FindElement((By.CssSelector("[class = 'button ajax_add_to_cart_button btn btn-default']")));
        }

        //botao para ir ao carrinho de compras
        public IWebElement BotaoCart()
        {
            return driver.FindElement((By.CssSelector("a[title='View my shopping cart']")));
        }

        public SearchResults(IWebDriver driver)
        {
            this.driver = driver;

        }

        //adicionando o produto ao carrinho de compras
        public void SelecionarProduto()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(ContainerProduto()).Perform();//mostrando as opções escondidas
            BotaoAddCart().Click();
            driver.Navigate().Refresh();
            BotaoCart().Click();
            
        }



    }
}
