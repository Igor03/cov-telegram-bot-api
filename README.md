<h1 align = "center">
<strong>Cov-Telegram Bot/API</strong>
</h1>

## Descrição
Nessa solução temos uma API que fornece dados sobre a situação de  contaminados por covid de cada país, e um cliente de integração com o telegram


## Tecnologias e ferramentas ultilizadas
* [.NetCore 3.1](https://dotnet.microsoft.com/download) - Framework utilizado para construir a Api deste repositório
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Linguagem usada para criar as funcionalidades da aplicação
* [Visual Studio 2017](https://visualstudio.microsoft.com/pt-br/) - IDE utilizada para desenvolvimento do projeto
* [Insomnia](https://insomnia.rest/) - Ferramenta utilizada para testar chamadas às API's utilizadas

## Instalação
Assumindo que você já possui o [GIT](https://git-scm.com/)  instalado em seu ambiente, clone o repositório usando o seguinte comando:
```
git https://github.com/Igor03/cov-telegram-bot-api.git
```
Navegue até o diretório 
```
cov-telegram-bot-api/
```
e abra a solução ``` ApiBotTelegram.sln ``` do projeto com usando uma IDE se sua preferencia.

Caso esteja usando o [Visual Studio]((https://visualstudio.microsoft.com/pt-br/)) como IDE, depois de abrir a solução, basta executá-la localmente.

## Importante
A base de dados deve ser criada localmente seguindo o seguinte [esquema](). O banco de dados utilizado foi o SQLServer, mas sinta-se à vontade para mudar, caso veja necessidade.
Pessoalmente, acredito que a melhor solução deveria ser a criação de um banco de dados SQLite.

O base de dados alimentada localmente por uma um web-crawler presente [aqui](https://github.com/Igor03/bot-covid19).
