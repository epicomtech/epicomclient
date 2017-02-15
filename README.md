# epicomclient
Cliente C# para a plataforma epicom

## Inicialização

O cliente suporta que sejam fornecidas as credebciais da API no momento da inicialização
   
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

