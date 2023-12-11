# <h1 align="center"> RunnerGame </h1>

<p align="center">
  <a href="#description">Description</a> •
  <a href="#features">Features</a> •
  <a href="#architecture">Architecture</a> •
  <a href="#technologies">Technologies</a> •
  <a href="#how-to-start-the-program">How to start the program</a> •
  <a href="#how-to-start-the-program--with-docker">How to start the program with docker</a> 
</p>

## 📃Description
This is prototype of my game in hyper-casual genre, the goal is to avoid as many obstacles as possible with difficulty of the game grows over time, game is a work in progress, as a reference i take "subway surfers" game 

## 🚀Features
|      Folders      |                                Description                                |
|:--------------------:|:-------------------------------------------------------------------------:|
|  Assets/Project/Scripts/PlayerScript  |      Allows you to get the generated HTML page from the application.      |
| GET /api/third-party |           Allows you to get data from a third-party API.                  |

## <p id="technologies">⚙️Technologies</p>
* JDK 17
* Maven 3.9.0
* Spring boot (WEB MVC, AOP) 3.1.4
* Swagger 2.1.0

## <p id="how-to-start-the-program">🔨How to start the program</p>
To run this application follow these steps:
* mvn clean
* cd to target package
* java -jar [name of your jar file].jar
* the access to the swagger page via [link](http://localhost:8080/swagger-ui/index.html#/) after application started

## <p id="how-to-start-the-program--with-docker">🐳How to run with docker</p>
To run this application in docker follow this steps:

You can use docker image from my [docker-hub](https://hub.docker.com/r/olehpryshchepa/docker-app) :
* docker pull olehpryshchepa/docker-app
* docker run -p 8081:8080 olehpryshchepa/docker-app
* the access to the swagger page via [link](http://localhost:8081/swagger-ui/index.html#/) after application started 

Or create your own image using dockerFile:
* mvn package
* docker build -t [name of your image] .
* docker run -p 8081:8080 [name of your image]
* the access to the swagger page via [link](http://localhost:8081/swagger-ui/index.html#/) after application started
