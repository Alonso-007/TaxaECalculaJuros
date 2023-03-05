# PROJETO DE CÁLCULO DE JUROS COMPOSTOS

Esse projeto realiza o cálculo para juros compostos.
Usando uma taxa fixa de 0.01 com valor inicial e um tempo em meses.


### 📋 Repositório

Na pasta scr e estão contidos os arquivos referentes a lógica do cálculo e na pasta teste os teste realizados do projeto.


## 🛠️ Construído com

* [Docker](https://www.docker.com/) - Gerenciador de containers.
* [Docker Compose](https://docs.docker.com/compose/) - Orquestrador de containers.
* [Visual Studio](https://visualstudio.microsoft.com/) - Ide utilizada para implementação da aplicação em conjunto com a linguagem c# e .net core 6.

## :building_construction: Execução do projeto

A execução do projeto pode ser feita de duas formas.
 - Feita direta pela ide visual studio 2022. Para isso realizar a clonagem ou download do repositório fazer build e execução dos projetos web api.
 - Usando o docker, para isso é necessário e o docker e docke-compose. Nesse caso depois da  clonagem ou download do repositório, acessar a pasta TaxaECalculaJuros\src e executar os seguintes comandos:
 
	docker build -t calculajurosapi:1.0 ./CalculaJuros.Api > cria a imagem
	<br />
	docker build -t taxasapi:1.0 ./Taxas.Api > cria a imagem

Depois acessar a pasta TaxaECalculaJuros e realizar os seguintes comandos:
	<br />
	docker-compose up -d > sobe a aplicação
	<br />
	docker-compose down > para a aplicação
