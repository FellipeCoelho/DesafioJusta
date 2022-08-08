#language: pt
Funcionalidade: Heroi realizara uma compra de produto

    Contexto: 
    Dado entrei no site na MyStore
    E escolhi um produto

  Esquema do Cenário: Dados validos de endereço de entrega
 #Aqui o teste termina quando o endereço de entrega é alterado e confirmado a alteração.

    Quando quero alterar endereco de entrega
    E altero os dados para <endereco>, <cidade>, <estado> e <cep>
    Então meu endereco <endereco>, <cidade>, <estado> e <cep> sera alterado com sucesso

    Exemplos: 
      | endereco             | cidade      | estado     | cep   |
      | 4965 S Centinela Ave | Los Angeles | California | 90066 |

    Esquema do Cenário: Dados válidos de endereço de cobrança
#Aqui o teste termina quando o endereço de cobrança é alterado e confirmado a alteração.


    Quando quero alterar endereco da cobranca
    E altero os dados para <endereco>, <cidade>, <estado> e <cep>
    Então meus dados <endereco>, <cidade>, <estado> e <cep> serao alterados

    Exemplos: 
      | endereco       | cidade     | estado  | cep   |
      | 825 N Shore Dr | Anna Maria | Florida | 34216 |

    Cenário: Cheque com dados válido
#Neste teste o fluxo da compra será completo.

    Quando escolho pagamento com cheque
    Então minha compra sera realizada com sucesso