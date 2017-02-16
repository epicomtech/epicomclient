# EpicomClient
Este pacote consiste em uma implementação de um cliente c# para integração via rest com a plataforma [Epicom](https://mhubapi.epicom.com.br/v1). 

---

[![NuGet version](https://badge.fury.io/nu/epicom.client.svg)](https://badge.fury.io/nu/Epicom.Client)

## Instalando via  Nuget

Install-Package Epicom.Client

## Credenciais de Acesso

As credenciais de acesso a API podem ser fornecidas no momento da inicialização do cliente
   
    var client = new EpicomClient(chave, token);

ou através do arquivo de configuração da aplicação

    var client = new EpicomClient();

## Arquivo Web.config/App.config

Adicionar as seguintes chaves à seção *appSettings*:

    <appSettings>    
      <add key="Epicom.Api.BaseUri" value="<Url de acesso a API>" />
      <add key="Epicom.Api.Key" value="<Chave de acesso a API>" />
      <add key="Epicom.Api.Token" value="<Token de acesso a API>" />
      ...
    </appSettings>
    
## Política de Retentativas

Caso o cliente receba uma resposta com status code maior que ou igual a 500 é possível se configurar o número de retentativas a serem feitas para API

      var client = new EpicomClient(chave, token, new RetryPolicyConfig { RetryCount = 5 });

