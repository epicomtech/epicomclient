# EpicomClient
EpicomClient implementa um cliente c# para integração via rest com a plataforma Epicom (https://mhubapi.epicom.com.br/v1). 

[![NuGet version](https://badge.fury.io/nu/epicom.client.svg)](https://badge.fury.io/nu/Epicom.Client)

## Instalando via  Nuget

Install-Package Epicom.Client

## Credenciais de Acesso

As credenciais devem ser fornecidas momento da inicialização do cliente
   
    var client = new EpicomClient(chave, token);

ou no arquivo de configuração da aplicação

    var client = new EpicomClient();

## Arquivo Web.config/App.config

Adicionar as seguintes chaves à seção *appSettings*:

    <appSettings>    
      <add key="Epicom.Api.BaseUri" value="<Url de acesso a API>" />
      <add key="Epicom.Api.Key" value="<Chave de acesso a API>" />
      <add key="Epicom.Api.Token" value="<Token de acesso a API>" />
      ...
    </appSettings>

