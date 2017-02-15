# epicomclient
Cliente c# para a plataforma epicom

## Pacote Nuget

https://www.nuget.org/packages/Epicom.Client/

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

