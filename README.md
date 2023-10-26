# Projeto de Monitoramento de Cotação de Ações

Este projeto é uma aplicação de console desenvolvida em C# para monitorar a cotação de ações da B3 e enviar alertas por e-mail quando o preço atinge determinados limites. 
Este README fornecerá as instruções necessárias para configurar e executar o projeto.

## Configuração

1. **Configurações de E-mail e SMTP:**
   - No arquivo `AppSettings.json`, configure as informações de e-mail e SMTP necessárias. Um exemplo de configuração é fornecido abaixo e está no `AppSettings-exemple.json

   ```json
   {
      "Email": {
        "_EmailAddressSender": "your-email@gmail.com",
        "EmailAddressSender": "wwddttnn@hotmail.com",
        "Password": "your email key/password",
        "EmailAddressRecipient": "email-recipient@gmail.com"
      },
      "Smtp": {
        "Server": "smtp.office365.com",
        "Server_gmail": "smtp.gmail.com",
        "Port": "587",
        "EnableSsl": true
      }
    }
    ```
    
## Parâmetros de Monitoramento:

Quando você chama o programa, forneça os seguintes parâmetros via linha de comando:
1. O ativo a ser monitorado.
2. O preço de referência para venda.
3. O preço de referência para compra.

Exemplo:

   ```shell
   .\stock-quote-alert.exe PETR4 10 20.33
   ```
    
### Executando o Projeto

1. Compilação:

Compile o projeto utilizando o ambiente de desenvolvimento de sua escolha (Visual Studio, Visual Studio Code, ou outra IDE).

2. Execução:

Execute o programa via linha de comando, fornecendo os parâmetros necessários. Por exemplo:

   ```shell
   .\stock-quote-alert.exe PETR4 10 20.33
   ```
   
3. Monitoramento Contínuo:

O programa ficará em execução, monitorando a cotação do ativo enquanto estiver rodando.




## Observações

No código, existem dois tipos de comentários:

Comentários com //: Esses são comentários que geralmente são deixados no código para outros desenvolvedores:

   ```shell
   // comentario aqui...
   ```


Comentários com //#: Estes são comentários nos quais justifico alguma escolha técnica para que o leitor compreenda a decisão. Normalmente, esses comentários não seriam incluídos em um código comum:


   ```shell
   //# comentario aqui...
   ```


Essa prática ajuda a distinguir os comentários comuns dos meta-comentários que explicam escolhas mais técnicas para fins didaticos.
