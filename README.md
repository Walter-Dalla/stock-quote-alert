# Projeto de Monitoramento de Cota��o de A��es

Este projeto � uma aplica��o de console desenvolvida em C# para monitorar a cota��o de a��es da B3 e enviar alertas por e-mail quando o pre�o atinge determinados limites. 
Este README fornecer� as instru��es necess�rias para configurar e executar o projeto.

## Configura��o

1. **Configura��es de E-mail e SMTP:**
   - No arquivo `AppSettings.json`, configure as informa��es de e-mail e SMTP necess�rias. Um exemplo de configura��o � fornecido abaixo e est� no `AppSettings-exemple.json

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
    
## Par�metros de Monitoramento:

Quando voc� chama o programa, forne�a os seguintes par�metros via linha de comando:
1. O ativo a ser monitorado.
2. O pre�o de refer�ncia para venda.
3. O pre�o de refer�ncia para compra.

Exemplo:

   ```shell
   .\stock-quote-alert.exe PETR4 10 20.33
   ```
    
### Executando o Projeto

1. Compila��o:

Compile o projeto utilizando o ambiente de desenvolvimento de sua escolha (Visual Studio, Visual Studio Code, ou outra IDE).

2. Execu��o:

Execute o programa via linha de comando, fornecendo os par�metros necess�rios. Por exemplo:

   ```shell
   .\stock-quote-alert.exe PETR4 10 20.33
   ```
   
3. Monitoramento Cont�nuo:

O programa ficar� em execu��o, monitorando a cota��o do ativo enquanto estiver rodando.




## Observa��es

No c�digo, existem dois tipos de coment�rios:

Coment�rios com //: Esses s�o coment�rios que geralmente s�o deixados no c�digo para outros desenvolvedores:

   ```shell
   // comentario aqui...
   ```


Coment�rios com //#: Estes s�o coment�rios nos quais justifico alguma escolha t�cnica para que o leitor compreenda a decis�o. Normalmente, esses coment�rios n�o seriam inclu�dos em um c�digo comum:


   ```shell
   //# comentario aqui...
   ```


Essa pr�tica ajuda a distinguir os coment�rios comuns dos meta-coment�rios que explicam escolhas mais t�cnicas para fins didaticos.
