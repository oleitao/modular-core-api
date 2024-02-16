# Estudos em .NET Core + EntityFramework + Docker + MYSQL

 - .NET Core 5.0
 - EntityFramework Core
 - Docker 
 - Docker-compose 3.4
 - Mysql 


## Requisitos:
	- Ter o docker instalado na m�quina

## Comandos: 
  Execu��o:
    - docker-compose build
    - docker-compose up
    
    util:
	docker-compose build && docker-compose up

  Uteis:
- docker network inspect bridge 
  - Informa��es sobre a rede dos containers
  -	**Ver se o container do mysql est� para 172.17.0.1, caso n�o, trocar dentro do docker-compose.yml**
   
 - docker container ls (Lista os containers)


## URL's

 *Ap�s o container ser iniciado

http://localhost:5001/api/  <---- Documentacao

http://localhost:5001/api/Produto <---------- /api/{Nome_Controller} tr�s os endpoints
