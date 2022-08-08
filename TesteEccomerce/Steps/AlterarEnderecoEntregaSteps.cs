using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TesteEccomerce.Pages;

namespace TesteEccomerce.Steps
{
    [Binding]
    public class AlterarEnderecoEntregaSteps
    {
        string url = "http://automationpractice.com/";
        IWebDriver driver;
        Home home;
        Authentication login;
        SearchResults results;
        Sumary sumary;
        Address address;
        AddressUpdate update;
        Shipping shipping;
        PaymentMethod payment;

        [Given(@"entrei no site na MyStore")]
        public void DadoEntreiNoSiteNaMyStore()
        {
            driver = new ChromeDriver();
            home = new Home(driver);
            login = new Authentication(driver);
            results = new SearchResults(driver);
            sumary = new Sumary(driver);
            address = new Address(driver);
            update = new AddressUpdate(driver);
            shipping = new Shipping(driver);
            payment = new PaymentMethod(driver);
            


            home.AbrirSite(url);
            home.ClicarEmSingIn();
            login.RealizarSingIn();
            
        }

        [Given(@"escolhi um produto")]
        public void DadoEscolhiUmProduto()
        {
            home.PesquisarProduto();
            results.SelecionarProduto();


        }
        
        [When(@"quero alterar endereco de entrega")]
        public void QuandoQueroAlterarEnderecoDeEntrega()
        {
            sumary.Prosseguir();
            address.EditarEnderecoEntrega();
        }

        [When(@"quero alterar endereco da cobranca")]
        public void QuandoQueroAlterarEnderecoDaCobranca()
        {
            sumary.Prosseguir();
            address.EditarEnderecoCobranca();
        }

        //a tela do site é a mesma para entrega e cobrança
        [When(@"altero os dados para (.*), (.*), (.*) e (.*)")]
        public void QuandoAlteroOsDadosPara(String endereco, String cidade, String estado, String cep)
        {
            //
            update.AlterarEndereco(endereco);
            update.AlterarCidade(cidade);
            update.AlterarEstado(estado);
            update.AlterarCep(cep);
            update.ClicarEmSalvar();
        }
        
        //endereço de entrega
        [Then(@"meu endereco (.*), (.*), (.*) e (.*) sera alterado com sucesso")]
        public void EntaoMeuEnderecoDeEntregaSeraAlteradoComSucesso(String endereco, String cidade, String estado, String cep)
        {
            address.verificaDadosEntrega(endereco, cidade, estado, cep);
        }

        //endereço de cobrança
        [Then(@"meus dados (.*), (.*), (.*) e (.*) serao alterados")]
        public void EntaoMeusDadosSeraoAlterados(String endereco, String cidade, String estado, String cep)
        {
            address.verificaDadosCobranca(endereco, cidade, estado, cep);
        }

        [When(@"escolho pagamento com cheque")]
        public void QuandoEscolhoPagamentoComCheque()
        {
            sumary.Prosseguir();
            address.Prosseguir();
            shipping.ConcordarTermosServicos();
            shipping.ProsseguirCheckout();
            payment.ClicarPagamentoCheque();
            payment.ConfirmarPedido();
            
        }

        [Then(@"minha compra sera realizada com sucesso")]
        public void EntaoMinhaCompraSeraRealizadaComSucesso()
        {
            payment.PedidoRealizado();
        }

    }
}
