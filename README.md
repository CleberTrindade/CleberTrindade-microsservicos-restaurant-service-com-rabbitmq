# Restaurante Service
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/CleberTrindade/microsservico-restaurant-service-com-rabbitmq/blob/main/LICENSE) 

# Sobre o projeto

Restaurante Service - Foram desenvolvidos 2 microservices, com o intuito de aplicação de conceitos de comunicação assíncrona, utilizando o RabbitMq.

Os serviços consistem em efetuar o cadastro dos Restaurantes pelo primeiro serviço restaurante-service, em seguida, uma mensagem é enviada para o segundo serviço item-service, que por sua vez, recebe a mensagem e atualiza sua base de dados, além de executar suas responsábilidades de cadastro e consulta de itens do restaurante.

## Layout restaurante-service
![service 1](https://github.com/CleberTrindade/microsservico-restaurant-service-com-rabbitmq/blob/desenv/assets/restaurant-service.JPG)

## Layout item-service
![service 2](https://github.com/CleberTrindade/microsservico-restaurant-service-com-rabbitmq/blob/desenv/assets/item-service.JPG)


## Modelo conceitual
![Modelo Conceitual](https://github.com/CleberTrindade/microsservico-restaurant-service-com-rabbitmq/blob/desenv/assets/modelo-conceitual.JPG)

# Tecnologias utilizadas
## Back end
- C#
- .Net 6
- Docker
- RabbitMq
- MySql

# Como executar o projeto

## Back end
Pré-requisitos: 
  .NET SDK 6.0 e Docker Desktop

```bash
# clonar repositório
git clone https://github.com/CleberTrindade/microsservico-restaurant-service-com-rabbitmq

# powershel ou terminal vscode
  - docker pull mcr.microsoft.com/dotnet/sdk:6.0
  - docker network create --driver bridge restaurante-bridge   
  - docker run --name=mysql-service -e MYSQL_ROOT_PASSWORD=root -d --network restaurante-bridge mysql:5.6
  - docker run -d --hostname rabbitmq-service --name rabbitmq-service --network restaurante-bridge rabbitmq:3-management
  
# executar o projeto
# entrar na pasta do projeto item-service
  cd item-service
  - docker build -t itemservice:1.0 .
  - docker run --name item-service -d -p 8080:80 --network restaurante-bridge itemservice:1.0

# entrar na pasta do projeto restauranteservice
  cd ..
  cd restauranteservice
  - docker build -t restauranteservice:1.0 .
  - docker run --name restaurante-service -p 8081:80 --network restaurante-bridge restauranteservice:1.0
  
# acessando os serviço
  - RestauranteService: http://localhost:8081/swagger/index.html
  - ItemService: http://localhost:8080/swagger/index.html
 
```

# Autor

Jose Cleber Santos Trindade

https://www.linkedin.com/in/cleber-trindade-net/

