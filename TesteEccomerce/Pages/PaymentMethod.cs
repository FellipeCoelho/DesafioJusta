using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEccomerce.Pages
{
    class PaymentMethod
    {
        private IWebDriver driver;

        //localizacao da opcao da pagamento por cheque
        private IWebElement botaoPagamentoCheque()
        {
            return driver.FindElement(By.ClassName("cheque"));
        }

        private IWebElement botaoConfirmarPedido()
        {
            return driver.FindElement(By.CssSelector("button[class='button btn btn-default button-medium']"));

        }

        //retorna verdadeiro ou falso se aparece o alert de pedido concluído
        private Boolean CompraConfirmada()
        {
            return alertaSucesso().Displayed;
        }

        //ao final da compra é exibida uma mensagem de sucesso, vamos usa-la para confirmar o final da automação
        private IWebElement alertaSucesso()
        {
            return driver.FindElement(By.CssSelector("[class='alert alert-success']"));
        }

        public PaymentMethod(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void ClicarPagamentoCheque()
        {
            botaoPagamentoCheque().Click();
        }

        public void ConfirmarPedido()
        {
            botaoConfirmarPedido().Click();
        }

        public void PedidoRealizado()
        {
            Assert.AreEqual(CompraConfirmada(),true);
        }
   

    }
}
